let calorieData = JSON.parse(localStorage.getItem("calorieData")) || [];
let weeklyGoal = localStorage.getItem("weeklyGoal") ? parseInt(localStorage.getItem("weeklyGoal")) : 0;

function updateGoalDisplay() {
    document.getElementById("currentGoalDisplay").textContent = weeklyGoal || 'Не е зададена цел';
}

function updateCalorieTable() {
    const tableBody = document.getElementById("calorieTableBody");
    tableBody.innerHTML = "";

    calorieData.forEach((data, index) => {
        const row = document.createElement("tr");
        const dateCell = document.createElement("td");
        const calorieCell = document.createElement("td");
        const actionCell = document.createElement("td");

        dateCell.textContent = new Date(data.date).toLocaleDateString("bg-BG");

        const calorieText = document.createElement("span");
        calorieText.textContent = data.calories.toFixed(1);
        calorieText.classList.add("calorie-text");

        const editButton = document.createElement("button");
        editButton.textContent = "Редактиране";
        editButton.classList.add("btn", "btn-warning", "btn-sm");
        editButton.addEventListener("click", function () {
            enableEdit(index, calorieText, editButton);
        });

        calorieCell.appendChild(calorieText);
        calorieCell.appendChild(editButton);

        const removeButton = document.createElement("button");
        removeButton.textContent = "Премахни";
        removeButton.classList.add("btn", "btn-danger", "btn-sm");
        removeButton.addEventListener("click", function () {
            removeCalories(index);
        });

        actionCell.appendChild(removeButton);

        row.appendChild(dateCell);
        row.appendChild(calorieCell);
        row.appendChild(actionCell);
        tableBody.appendChild(row);
    });

    updateProgress();
    checkMissedDay();
}

function enableEdit(index, calorieText, editButton) {
    const calorieInput = document.createElement("input");
    calorieInput.type = "number";
    calorieInput.value = parseFloat(calorieText.textContent);
    calorieInput.classList.add("form-control", "edit-input");

    const saveButton = document.createElement("button");
    saveButton.textContent = "Запази";
    saveButton.classList.add("btn", "btn-success", "btn-sm");
    saveButton.addEventListener("click", function () {
        const newCalories = parseFloat(calorieInput.value);
        if (!isNaN(newCalories) && newCalories > 0) {
            calorieData[index].calories = newCalories;
            localStorage.setItem("calorieData", JSON.stringify(calorieData));
            updateCalorieTable();
        }
    });

    editButton.replaceWith(saveButton);
    calorieText.replaceWith(calorieInput);
}

function updateProgress() {
    const totalCalories = calorieData.reduce((total, data) => total + data.calories, 0);
    const progressPercentage = weeklyGoal > 0 ? (totalCalories / weeklyGoal) * 100 : 0;

    if (progressPercentage > 100) {
        document.getElementById("goalError").style.display = "block";
    } else {
        document.getElementById("goalError").style.display = "none";
    }

    const progressBar = document.getElementById("progressBar");
    const progressSummary = document.getElementById("progressSummary");

    progressBar.style.width = `${Math.min(progressPercentage, 100)}%`;
    progressSummary.textContent = `Прогрес: ${Math.min(progressPercentage, 100).toFixed(1)}% от целта.`;
}

function checkMissedDay() {
    const today = new Date().toLocaleDateString("bg-BG");
    const lastEntry = calorieData.length > 0 ? new Date(calorieData[calorieData.length - 1].date).toLocaleDateString("bg-BG") : '';

    if (today !== lastEntry) {
        document.getElementById("missedDayMessage").style.display = "block";
    } else {
        document.getElementById("missedDayMessage").style.display = "none";
    }
}

document.getElementById("caloriesForm").addEventListener("submit", function (event) {
    event.preventDefault();
    const caloriesInput = document.getElementById("calories").value;
    const calories = parseFloat(caloriesInput);

    if (!isNaN(calories) && calories > 0) {
        const today = new Date().toLocaleDateString("bg-BG");

        const alreadyAdded = calorieData.some(entry =>
            new Date(entry.date).toLocaleDateString("bg-BG") === today
        );

        const errorMessage = document.getElementById("errorMessage");

        if (alreadyAdded) {
            errorMessage.textContent = "Вече сте добавили калории за днешния ден!";
            errorMessage.style.display = "block";
            return;
        }

       
        errorMessage.style.display = "none";

   
        const date = new Date();
        calorieData.push({ date: date, calories: calories });
        localStorage.setItem("calorieData", JSON.stringify(calorieData));
        updateCalorieTable();
        document.getElementById("calories").value = "";
    }
});

function removeCalories(index) {
    calorieData.splice(index, 1);
    localStorage.setItem("calorieData", JSON.stringify(calorieData));
    updateCalorieTable();
}

document.getElementById("editGoalButton").addEventListener("click", function () {
    document.getElementById("goalForm").style.display = "block";
    document.getElementById("editGoalButton").style.display = "none";
});

document.getElementById("goalForm").addEventListener("submit", function (event) {
    event.preventDefault();
    const newGoal = parseInt(document.getElementById("weeklyGoal").value);

    if (!isNaN(newGoal) && newGoal > 0) {
        weeklyGoal = newGoal;
        localStorage.setItem("weeklyGoal", weeklyGoal);
        updateGoalDisplay();
        document.getElementById("goalForm").style.display = "none";
        document.getElementById("editGoalButton").style.display = "block";
        updateProgress();
    }
});

updateGoalDisplay();
updateCalorieTable();
