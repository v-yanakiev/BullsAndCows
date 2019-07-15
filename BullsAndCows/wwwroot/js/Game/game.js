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
                attachInitialHandler();
            }
        })
        .fail(function (data) {
            debugger;
        });
    }
    function attachInitialHandler() {
        $("#initialForm").submit(function (event) { event.preventDefault(); submitFirstNumber(); });
    }
    function submitFirstNumber() {
        let value = $("#numberWhichAIsSupposedToGuess").val();
        if (!$.isNumeric(value)) {
            UI().displayInvalidInputError();
            return;
        } else if (value.length != 4 || Number(value) < 0) {
            UI().displayInvalidInputError();
            return;
        }
        UI().displayLoading();
        $.post({
            url: "/api/game/init",
            data: JSON.stringify({ "numberToGuess": value }),
            headers: {"Content-Type":"application/json"}
        }).done(function (data) {
            beginGame(data);
        }).fail(function (data) {
            UI().hideLoading();
            UI().displayConnectionError();
        });
    }
    
}
function beginGame(data) {
    debugger;
    if (data.numberWhichAIMustGuess == undefined) {
        renderGame(data);
    } else {
        renderGame(data.numberWhichAIMustGuess);
    }
    UI().displaySuccessMessage("Okay, I have also thought of a number for you. You go first...");
    attachHandlers();
    function renderGame(numberForAIToGuess) {
        $("#gamingField").text("");
        UI().hideLoading();
        $("#gamingField").load("/html/game.html", function () {
            $("#numberForAI").text(numberForAIToGuess);
            attachHandlers();
            fillWithGuesses(data);
        });
    }
    function fillWithGuesses(data) {
        if (data.userGuesses == undefined) {
            return;
        }
        debugger;
        let userRows = $("#userGuesses").children();
        let br = 0;
        for (let row of userRows) {
            if (data.userGuesses.length <= br) {
                break;
            }
            $($(row).children()[0]).text(data.userGuesses[br].value);
            $($(row).children()[1]).text
                (UI().formatResult(data.userGuesses[br].guessOutcome));
            br++;
        }
        br = 0;
        let aiRows = $("#AIGuesses").children();
        for (let row of aiRows) {
            if (data.aiGuesses.length <= br) {
                break;
            }
            $($(row).children()[0]).text(data.aiGuesses[br].value);
            $($(row).children()[1]).text
                (UI().formatResult(data.aiGuesses[br].guessOutcome));
            br++;
        }
    }
    function attachHandlers() {
        $("#userGuessForm").submit(function (e) {
            e.preventDefault();
            let userGuess = $("#userGuess").val();
            debugger;
            UI().displayLoading();
            $.post({
                url: "/api/game/play",
                data: JSON.stringify({ "Value": userGuess }),
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
                debugger;
                UI().hideLoading();
                UI().displayConnectionError();
            });
        });
    }
    function fillNextRow(data) {
        if (data.userGuess == undefined) {
            return;
        }
        debugger;
        let userRows = $("#userGuesses").children();
        let test = userRows.children().first();
        let rowToFill = userRows.filter(a => $(a).children().first().text() == "").first();
        $(rowToFill.children()[0]).text(data.userGuess.value);
        $(rowToFill.children()[1]).text(UI().formatResult(data.userGuess.guessOutcome));
        let aiRows = $("#AIGuesses").children();
        rowToFill = aiRows.filter(a => $(a).children().first().text() == "").first();
        $(rowToFill.children()[0]).text(data.aiGuess.value);
        $(rowToFill.children()[1]).text(UI().formatResult(data.aiGuess.guessOutcome));
    }
}
function UI() {
    function gameOverMessage(message) {
        $("#gamingField").append($("<h2>").text(message));
        $("#userGuessForm").off();
        $("#userGuessForm").submit(function (e) { e.preventDefault(); });
    }
    function formatResult(result) {
        return result.bullsNumber + " Bulls and " + result.cowsNumber + " Cows";
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
        $("#loading").fadeIn(100);
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