function updateStatus(partyId, action) {
    document.getElementById('partyId').value = partyId;
    document.getElementById('Action').value = action;
    document.getElementById('myForm').submit();
}

window.addEventListener('DOMContentLoaded', (event) => {
    var messageElement = document.getElementById('statusMessage');
    var actionElement = document.getElementById('action');

    // Kiểm tra xem cả message và action đều không phải là null và không phải là empty string
    if (messageElement && actionElement && messageElement.value.trim() && actionElement.value.trim()) {
        var message = messageElement.value;
        var action = actionElement.value;
        showToast(message, action);
    }
});

function showMess(partyId, action) {
    var btnToastDelete = document.querySelector('#btn-toast-delete');
    var btnToastRemove = document.querySelector('#btn-toast-remove');

    btnToastDelete.addEventListener('click', function () {
        updateStatus(partyId, action);
        document.getElementById('modalConfirmDelete').style.display = 'none';
    });
    btnToastRemove.addEventListener('click', function () {
        updateStatus(partyId, action);
        document.getElementById('modalConfirmRemove').style.display = 'none';
    });
}

function showToast(message, action) {
    const toast = document.getElementById('toast-notification');
    const toastMessage = document.getElementById('toast-message');
    const toastContainer = document.getElementById('toast-container');
    toastContainer.style.display = 'block';

    if (message === 'success') {
        if (action === 'isApprove') {
            var success = 'This party has been reactive!';
        } else if (action === 'isDeny') {
            var success = 'This party has been inactive!';
        } else if (action === 'create') {
            var success = 'This party has been create!';
        } else if (action === 'update') {
            var success = 'This party has been update!';
        } else {
            var success = 'This party has been remove!';
        }
        toastMessage.classList.add('text-success');
        toastMessage.textContent = success;
    } else if (message === 'fail') {
        if (action === 'isApprove') {
            var fail = `Can't reactive this party!`;
        } else if (action === 'isDeny') {
            var fail = `Can't inactive this party!`;
        } else if (action === 'create') {
            var fail = `Can't create this party!`;
        } else if (action === 'update') {
            var fail = `Can't update this party!`;
        } else {
            var fail = `Can't remove this party!`;
        }
        toastMessage.classList.add('text-danger');
        toastMessage.textContent = fail;
    } else if (message === 'used') {
        var fail = `This party cannot be deactivated because it is already in use!`;
        toastMessage.classList.add('text-danger');
        toastMessage.textContent = fail;
    }
    else {
        var error = 'Error! Please try again.';
        toastMessage.classList.add('text-danger');
        toastMessage.textContent = error;
    }

    toast.classList.remove('hide');
    toast.classList.add('show');
    setTimeout(() => {
        toast.classList.remove('show');
    }, 3000);
}