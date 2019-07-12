$(document).ready(init);
function init() {
    $("#initialForm").submit(function (event) { event.preventDefault(); submitFirstNumber(); });
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
function beginGame(numberForAIToGuess) {
    renderGame(numberForAIToGuess);
    UI().displaySuccessMessage("Okay, I have also thought of a number for you. You go first...");
    function renderGame(numberForAIToGuess) {
        $("#gamingField").text("");
        UI().hideLoading();
        $("#gamingField").load("/html/game.html", function () {
            $("#numberForAI").text(numberForAIToGuess);
        });
    }
    function attachHandlers() {
        $("#initialForm").submit(function () {
            let userGuess = $("#userGuess").val();
            UI().displayLoading();
            $.post({
                url: "/api/game/play",
                data: JSON.stringify({ "userGuess": userGuess }),
                headers: { "Content-Type": "application/json" }
            }).done(function (data) {
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
        $("#successAlert").fadeOut(4000);
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