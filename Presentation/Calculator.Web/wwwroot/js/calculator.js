document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('tariffForm');
    const countrySelect = document.getElementById('countryId');
    const weightInput = document.getElementById('weight');

    form.addEventListener('submit', handleFormSubmit);

    countrySelect.addEventListener('change', clearErrors);
    weightInput.addEventListener('input', clearErrors);

    const countryCountryMap = {
        1: 'India',
        2: 'US',
        3: 'UK'
    };

    const tariffPerKgMap = {
        1: 5.00,
        2: 8.00,
        3: 10.00
    };
});

function clearErrors() {
    document.getElementById('countryError').textContent = '';
    document.getElementById('weightError').textContent = '';
}

function validateForm() {
    clearErrors();
    let isValid = true;

    const countryId = document.getElementById('countryId').value;
    if (!countryId) {
        document.getElementById('countryError').textContent = 'Debe seleccionar un país.';
        isValid = false;
    }

    const weight = parseFloat(document.getElementById('weight').value);
    if (!weight || weight <= 0) {
        document.getElementById('weightError').textContent = 'El peso debe ser mayor a cero.';
        isValid = false;
    }

    if (weight > 70) {
        document.getElementById('weightError').textContent = 'El peso no puede exceder 70 kg.';
        isValid = false;
    }

    return isValid;
}

async function handleFormSubmit(event) {
    event.preventDefault();

    if (!validateForm()) {
        return;
    }

    hideAllContainers();
    showLoadingContainer();

    const countryId = parseInt(document.getElementById('countryId').value);
    const weight = parseFloat(document.getElementById('weight').value);

    const request = {
        countryId: countryId,
        weight: weight
    };

    try {
        const response = await fetch('/api/tariff/calculate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(request)
        });

        const result = await response.json();

        if (result.success) {
            displayResult(result.data);
        } else {
            displayError(result.message);
        }
    } catch (error) {
        console.error('Error:', error);
        displayError('Ha ocurrido un error inesperado. Por favor, intente de nuevo.');
    }
}

function displayResult(data) {
    hideAllContainers();

    document.getElementById('resultCountry').textContent = data.countryName;
    document.getElementById('resultWeight').textContent = data.weight.toFixed(2);
    document.getElementById('resultTariffPerKg').textContent = data.tariffPerKg.toFixed(2);
    document.getElementById('resultTotal').textContent = data.totalCost.toFixed(2);

    document.getElementById('resultContainer').classList.remove('d-none');
}

function displayError(message) {
    hideAllContainers();
    document.getElementById('errorMessage').textContent = message;
    document.getElementById('errorContainer').classList.remove('d-none');
}

function hideAllContainers() {
    document.getElementById('resultContainer').classList.add('d-none');
    document.getElementById('errorContainer').classList.add('d-none');
    document.getElementById('loadingContainer').classList.add('d-none');
}

function showLoadingContainer() {
    document.getElementById('loadingContainer').classList.remove('d-none');
}

function resetForm() {
    document.getElementById('tariffForm').reset();
    hideAllContainers();
    clearErrors();
    document.getElementById('countryId').focus();
}
