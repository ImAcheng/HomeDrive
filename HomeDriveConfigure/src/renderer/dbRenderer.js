const serverInput = document.getElementById("server");
const usernameInput = document.getElementById("username");
const passwordInput = document.getElementById("password");

const connectButton = document.getElementById("btn-connect");
const createButton = document.getElementById("btn-create");
const returnButton = document.getElementById("btn-return");

const status = document.getElementById("status");

function getDatabaseConfig() {
    return {
        server: serverInput.value.trim(),
        username: usernameInput.value,
        password: passwordInput.value
    };
}

function showStatus(message, success) {
    status.textContent = message;

    status.classList.remove("hidden", "success", "error");

    status.classList.add(success ? "success" : "error");
}

function setLoading(loading) {
    connectButton.disabled = loading;
    createButton.disabled = loading;
}

function returnToIndex() {
    document.location.assign("index.html");
}

connectButton.addEventListener("click", async () => {

    const config = getDatabaseConfig();

    setLoading(true);
    showStatus("Connecting...", true);

    try {

        const result =
            await window.homeDrive.database.testConnection(config);

        if (result.success) {
            showStatus("Connected successfully.", true);
        }
        else {
            showStatus(result.message, false);
        }

    }
    catch (error) {
        showStatus(error.message, false);
    }
    finally {
        setLoading(false);
    }
});

createButton.addEventListener("click", async () => {

    const config = getDatabaseConfig();

    setLoading(true);
    showStatus("Creating database...", true);

    try {

        const result =
            await window.homeDrive.database.create(config);

        if (result.success) {
            showStatus("Database created.", true);
        }
        else {
            showStatus(result.message, false);
        }

    }
    catch (error) {
        showStatus(error.message, false);
    }
    finally {
        setLoading(false);
    }
});

returnButton.addEventListener("click", () => {
    returnToIndex()
})