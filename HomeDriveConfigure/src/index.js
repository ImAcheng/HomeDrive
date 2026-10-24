const { app, BrowserWindow, Menu, ipcMain } = require('electron');
const path = require('node:path');
const sql = require('mssql')
const crypto = require('crypto')
const { spawn } = require("child_process");

if (require('electron-squirrel-startup')) {
  app.quit();
}

const createWindow = () => {
  Menu.setApplicationMenu(null)

  const mainWindow = new BrowserWindow({
    width: 900,
    height: 700,
    webPreferences: {
      preload: path.join(__dirname, 'preload.js'),
    },
  });

  // and load the index.html of the app.
  mainWindow.loadFile(path.join(__dirname, 'index.html'));

  // This open the DevTools.
  // I don't think this should be shown tho.
  // mainWindow.webContents.openDevTools();
};

function createSqlConfig(config, db) {
    let server = config.server;
    let port = config.port;

    const index = server.indexOf("\\");

    let instance;

    if (index !== -1) {
        instance = server.substring(index + 1);
        server = server.substring(0, index);

        if (server === ".") {
            server = "localhost";
        }
    }

    return {
        server,
        port: Number(port),
        user: config.username,
        password: config.password,
        database: db,

        options: {
            encrypt: true,
            trustServerCertificate: true,

            ...(instance
                ? {
                    instanceName: instance
                }
                : {})
        }
    };
}

ipcMain.handle(
    "database:test-connection",
    async (_, config) => {

        try {

            const pool = await sql.connect(
                createSqlConfig(config)
            );

            await pool.close();

            return {
                success: true
            };

        }
        catch (error) {

            return {
                success: false,
                message: error.message
            };

        }
    }
);

// this script might be updated some day
const DbTableScript = `
    CREATE TABLE Account (
        AccountId uniqueidentifier NOT NULL PRIMARY KEY,
        Username nvarchar(63) NOT NULL,
        LoginPassword nvarchar(511) NOT NULL
    );

    CREATE TABLE FileDirData (
        FileDirDataId uniqueidentifier NOT NULL PRIMARY KEY,
        AccountId uniqueidentifier NOT NULL FOREIGN KEY REFERENCES Account(AccountId),
        Type tinyint NOT NULL CHECK (Type IN (0, 1)),
        FileDirName nvarchar(511) NOT NULL,
        ParentDirId uniqueidentifier NULL,
        MimeType nvarchar(63) NULL,
        Status tinyint NOT NULL DEFAULT 0,
        PrivacyPolicy tinyint NOT NULL DEFAULT 0,
        CreateDateTime datetimeoffset NOT NULL
    );

    CREATE TABLE FileDirAccess (
        FileDirAccessId uniqueidentifier NOT NULL PRIMARY KEY,
        FileDirDataId uniqueidentifier NOT NULL FOREIGN KEY REFERENCES FileDirData(FileDirDataId),
        AccountId uniqueidentifier NOT NULL FOREIGN KEY REFERENCES Account(AccountId)
    );
`;

ipcMain.handle(
    "database:create",
    async (_, config) => {

        let pool;

        try {
            pool = await sql.connect(
                createSqlConfig(config, "master")
            );

            await pool.request().query(`
                IF DB_ID(N'HomeDrive') IS NULL
                BEGIN
                    CREATE DATABASE HomeDrive;
                END;
            `);

            await pool.close();

            pool = await sql.connect(
                createSqlConfig(config, "HomeDrive")
            );
            
            
            await pool.request().query(DbTableScript);

            return {
                success: true
            };

        }
        catch (error) {

            if (pool) {
                try {
                    await pool.close();
                }
                catch {
                }
            }

            return {
                success: false,
                message: error.message
            };

        }
    }
);

// API Program
let apiProcess = null;

function isApiRunning() {
    return apiProcess !== null;
}

function getApiPath() {
    if (!app.isPackaged) {
        return path.join(
            __dirname,
            "..",
            "api_program",
            "api.exe"
        );
    }

    return path.join(
        process.resourcesPath,
        "api_program",
        "api.exe"
    );
}

function startApi() {
    if (isApiRunning()) {
        return false;
    }

    const apiPath = getApiPath();

    apiProcess = spawn(apiPath, [], {
        cwd: path.dirname(apiPath),
        windowsHide: true
    });

    apiProcess.on("exit", () => {
        apiProcess = null;

        /*
        if (mainWindow && !mainWindow.isDestroyed()) {
            mainWindow.webContents.send(
                "api-status",
                false
            );
        } */
    });

    return true;
}

function stopApi() {
    if (!apiProcess) {
        return false;
    }

    apiProcess.kill();
    apiProcess = null;

    return true;
}

ipcMain.handle("api:get-status", () => {
    return isApiRunning();
});

ipcMain.handle("api:start", () => {
    return startApi();
});

ipcMain.handle("api:stop", () => {
    return stopApi();
});

app.whenReady().then(() => {
  createWindow();
  app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) {
      createWindow();
    }
  });
});

app.on('before-quit', () => {
    if (apiProcess) {
        apiProcess.kill();
        apiProcess = null;
    }
})

// Some debug for OS X (macOS)
app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit();
  }
});
