$(document).ready(init);
function init() {
    checkForExistingGame();
    function checkForExistingGame() {
        UI().displayLoading();
        $.get("/api/game/data", function (data) {
            UI().hideLoading();
            if (data.gameExists) {
                beginGame(data);
            } else {
                loadInitial();
            }
        })
        .fail(function (data) {
        });
    }
    function loadInitial() {
        UI().displayLoading();
        $("#gamingField").load("/html/index.html", function () {
            UI().hideLoading();
            $("#initialForm").submit(function (event) { event.preventDefault(); submitInitializingNumber(); });
        });
    }
    
    function submitInitializingNumber() {
        let value = $("#numberWhichAIsSupposedToGuess").val();
        if (!isLegitimate(value)) {
            UI().displayInvalidInputError();
            return;
        }
        UI().displayLoading();
        $.post({
            url: "/api/game/init",
            data: JSON.stringify({ "numberToGuess": value }),
            headers: {"Content-Type":"application/json"}
        }).done(function (data) {
            UI().hideLoading();
            beginGame(data);
        }).fail(function (data) {
            UI().hideLoading();
            UI().displayConnectionError();
        });
    }
    
}
function beginGame(data) {
    if (data.numberWhichAIMustGuess == undefined) {
        renderGame(data);
    } else {
        renderGame(data.numberWhichAIMustGuess);
    }
    function renderGame(numberForAIToGuess) {
        $("#gamingField").text("");
        UI().displayLoading();
        $("#gamingField").load("/html/game.html", function () {
            $("#numberForAI").text(numberForAIToGuess);
            attachHandlers();
            fillWithGuesses(data);
            UI().hideLoading();
            if (data.numberWhichAIMustGuess == undefined) {
                UI().displaySuccessMessage("Okay, I have also thought of a number for you. You go first...");
            }
        });
    }
    function fillWithGuesses(data) {
        if (data.userGuesses == undefined) {
            return;
        }
        let userField = $("#userGuesses");
        for (let guess of data.userGuesses) {
            $(userField).append($("<tr>").append($("<td>").text(guess.value)).append($("<td>").text(UI().formatResult(guess.guessOutcome))));
        }
        let aiField = $("#AIGuesses");
        for (let guess of data.aiGuesses) {
            $(aiField).append($("<tr>").append($("<td>").text(guess.value)).append($("<td>").text(UI().formatResult(guess.guessOutcome))));
        }
    }
    function attachHandlers() {
        $("#userGuessForm").submit(function (e) {
            e.preventDefault();
            let value = $("#userGuess").val();
            if (!isLegitimate(value)) {
                UI().displayInvalidInputError();
                return;
            }
            UI().displayLoading();
            $.post({
                url: "/api/game/play",
                data: JSON.stringify({ "Value": value }),
                headers: { "Content-Type": "application/json" }
            }).done(function (data) {
                fillNextRow(data);
                UI().hideLoading();
                if (data.aiVictory) {
                    UI().gameOverMessage("AI Wins!");
                    return;
                } else if (data.userVictory) {
                    UI().gameOverMessage("You Win!");
                    return;
                }

            }).fail(function (data) {
                UI().hideLoading();
                UI().displayConnectionError();
            });
        });
    }
    function fillNextRow(data) {
        if (data.userGuess == undefined) {
            return;
        }
        let userField = $("#userGuesses");
        $(userField).append($("<tr>").append($("<td>").text(data.userGuess.value)).append($("<td>").text(UI().formatResult(data.userGuess.guessOutcome))));
        if (data.aiGuess == null) {
            return;
        }
        let aiField = $("#AIGuesses");
        $(aiField).append($("<tr>").append($("<td>").text(data.aiGuess.value)).append($("<td>").text(UI().formatResult(data.aiGuess.guessOutcome))));

    }

}
function isLegitimate(value) {
    let regex = /^(?!.*(.).*\1)\d{4}$/;
    return regex.test(value);
}
function UI() {
    function gameOverMessage(message) {
        $("#gamingField").append($("<h2>").text(message));
        $("#userGuessForm").off();
        $("#userGuessForm").submit(function (e) { e.preventDefault(); });
    }
    function formatResult(result) {
        let toReturn = "";
        if (result.bullsNumber == 1) {
            toReturn += result.bullsNumber + " Bull and ";
        } else {
            toReturn += result.bullsNumber + " Bulls and ";
        }
        if (result.cowsNumber == 1) {
            toReturn += result.cowsNumber + " Cow";
        } else {
            toReturn += result.cowsNumber + " Cows";
        }
        return toReturn;
    }
    function displayInvalidInputError() {
        $("#errorMessage").text("Invalid Input!");
        $("#errorMessage").show();
        $("#errorMessage").fadeOut(2000);
    }
    function displaySuccessMessage(text) {
        $("#successAlert").text(text);
        $("#successAlert").show();
        $("#successAlert").fadeOut(5000);
    }
    function displayConnectionError() {
        $("#errorMessage").text("Error, please try again...");
        $("#errorMessage").show();
        $("#errorMessage").fadeOut(2000);
    }
    function displayLoading() { 
        $("#loading").show();
    }
    function hideLoading() {
        $("#loading").hide();
    }
    return {
        displayInvalidInputError: displayInvalidInputError,
        displayConnectionError: displayConnectionError,
        displayLoading: displayLoading,
        hideLoading: hideLoading,
        displaySuccessMessage: displaySuccessMessage,
        formatResult: formatResult,
        gameOverMessage: gameOverMessage
    };
}