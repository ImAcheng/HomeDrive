const apiStatus = document.getElementById("apiStatus");
const apiStatusText = document.getElementById("apiStatusText");
const apiButton = document.getElementById("apiButton");
const message = document.getElementById("message");

const returnButton = document.getElementById("btn-return");


function updateApiUI(running) {
    if (running) {
        apiStatus.classList.remove("stopped");
        apiStatus.classList.add("running");

        apiStatusText.textContent = "Running";
        apiButton.textContent = "Close API";
    }
    else {
        apiStatus.classList.remove("running");
        apiStatus.classList.add("stopped");

        apiStatusText.textContent = "Not Running";
        apiButton.textContent = "Lauch API";
    }
}


function showMessage(text, type) {
    message.textContent = text;

    message.classList.remove(
        "hidden",
        "success",
        "error"
    );

    message.classList.add(type);
}


function hideMessage() {
    message.classList.add("hidden");
}

function returnToIndex() {
    document.location.assign("index.html");
}

apiButton.addEventListener("click", async () => {

    apiButton.disabled = true;
    hideMessage();

    try {

        const running =
            await window.apiManager.getStatus();

        if (running) {

            await window.apiManager.stop();

            showMessage(
                "API closed.",
                "success"
            );

        }
        else {

            const result =
                await window.apiManager.start();

            if (result) {

                showMessage(
                    "API lauched successfully.",
                    "success"
                );

            }
            else {

                showMessage(
                    "Failed to lauch API.",
                    "error"
                );
            }
        }

    }
    catch (error) {

        console.error(error);

        showMessage(
            "Error while API opereating.",
            "error"
        );

    }
    finally {

        apiButton.disabled = false;

        const status =
            await window.apiManager.getStatus();

        updateApiUI(status);
    }
});


// when api closed itself, ipcmain will send event
// yeah but, that is what is should be.
// I have no time to handle this problem now.
window.apiManager.onStatusChanged((running) => {
    updateApiUI(running);
});


// get status when loaded
(async () => {

    const running =
        await window.apiManager.getStatus();

    updateApiUI(running);

})();

returnButton.addEventListener("click", () => {
    returnToIndex()
})