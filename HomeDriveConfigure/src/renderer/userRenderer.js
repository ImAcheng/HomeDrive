const usernameInput = document.getElementById("username");
const passwordInput = document.getElementById("password");
const confirmPasswordInput = document.getElementById("confirmPassword");

const createAccountButton = document.getElementById("createAccount");
const createMessage = document.getElementById("createMessage");

const returnButton = document.getElementById("btn-return");

const API_URL = "http://localhost:5000"

function showMessage(message, type) {
    createMessage.hidden = false;
    createMessage.textContent = message;

    createMessage.classList.remove(
        "success",
        "error"
    );

    createMessage.classList.add(type);
}

function returnToIndex() {
    document.location.assign("index.html");
}

createAccountButton.addEventListener("click", async () => {
    createMessage.hidden = true;

    const username = usernameInput.value.trim();
    const password = passwordInput.value;
    const confirmPassword = confirmPasswordInput.value;


    if (username.length === 0) {
        showMessage("Please enter a username.", "error");
        return;
    }

    if (password.length === 0) {
        showMessage("Please enter a password.", "error");
        return;
    }

    if (password !== confirmPassword) {
        showMessage("Passwords do not match.", "error");
        return;
    }


    createAccountButton.disabled = true;
    createAccountButton.textContent = "Creating...";


    try {
        const response = await fetch(
            `${API_URL}/api/account/create`,
            {
                method: "POST",

                headers: {
                    "Content-Type": "application/json"
                },

                body: JSON.stringify({
                    Username: username,
                    Password: password
                })
            }
        );


        if (!response.ok) {
            let message = "Failed to create account.";

            try {
                const data = await response.json();

                if (data.message) {
                    message = data.message;
                }
            }
            catch {
                // Response does not contain JSON.
            }

            throw new Error(message);
        }


        showMessage(
            "Account created successfully.",
            "success"
        );


        usernameInput.value = "";
        passwordInput.value = "";
        confirmPasswordInput.value = "";

    }
    catch (error) {
        console.error(error);

        showMessage(
            error.message || "Failed to create account.",
            "error"
        );
    }
    finally {
        createAccountButton.disabled = false;
        createAccountButton.textContent = "Create Account";
    }
});

returnButton.addEventListener("click", () => {
    returnToIndex()
})