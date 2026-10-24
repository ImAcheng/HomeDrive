// See the Electron documentation for details on how to use preload scripts:
// https://www.electronjs.org/docs/latest/tutorial/process-model#preload-scripts

const { contextBridge, ipcRenderer } = require("electron");


contextBridge.exposeInMainWorld("homeDrive", {

    database: {

        testConnection: (config) =>
            ipcRenderer.invoke(
                "database:test-connection",
                config
            ),

        create: (config) =>
            ipcRenderer.invoke(
                "database:create",
                config
            )

    }

});

contextBridge.exposeInMainWorld("apiManager", {
    getStatus: () => {
        return ipcRenderer.invoke("api:get-status");
    },

    start: () => {
        return ipcRenderer.invoke("api:start");
    },

    stop: () => {
        return ipcRenderer.invoke("api:stop");
    },

    onStatusChanged: (callback) => {
        ipcRenderer.on("api-status", (_, status) => {
            callback(status);
        });
    }
});
