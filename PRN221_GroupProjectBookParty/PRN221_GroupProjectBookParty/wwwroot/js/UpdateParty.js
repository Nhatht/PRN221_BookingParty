   function previewImage(event) {
        var input = event.target;
    var reader = new FileReader();

    reader.onload = function() {
            var imgElement = document.getElementById('imagePreview');
    imgElement.src = reader.result;
    imgElement.style.display = 'block';
        };

    reader.readAsDataURL(input.files[0]);
    }
