$(document).ready(init);
function init() {
    checkForExistingGame();
    function checkForExistingGame() {
        UI().displayLoading();
        $.get("/api/game/data", function (data) {
            UI().hideLoading();
            debugger;
            if (data.gameExists) {
                beginGame(data);
            } else {
                attachInitialHandler();
            }
            debugger;
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
            beginGame(value);
        }).fail(function (data) {
            UI().hideLoading();
            UI().displayConnectionError();
        });
    }
    
}
function beginGame(data) {
    renderGame(data.numberWhichAIMustGuess);
    UI().displaySuccessMessage("Okay, I have also thought of a number for you. You go first...");
    attachHandlers();
    function renderGame(numberForAIToGuess) {
        $("#gamingField").text("");
        UI().hideLoading();
        $("#gamingField").load("/html/game.html", function () {
            $("#numberForAI").text(numberForAIToGuess);
            attachHandlers();
        });
    }
    function fillWithGuesses(data) {
        let userRows = $("#userGuesses").children();
        let br = 0;
        for (let row of userRows) {
            $($(row).children()[0]).text(data.userGuesses[br].value);
            $($(row).children()[1]).text
                (data.userGuesses[br].bullNumber + " bulls and " + data.userGuesses[br].cowNumber + " cows");
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
                data: JSON.stringify({ "value": userGuess }),
                headers: { "Content-Type": "application/json" }
            }).done(function (data) {
                debugger;
                UI().hideLoading();
            }).fail(function (data) {
                UI().hideLoading();
                UI().displayConnectionError();
            });
        });
    }
}
function UI() {
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
        displaySuccessMessage: displaySuccessMessage
    };
}