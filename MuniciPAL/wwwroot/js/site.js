const fileInput = document.getElementById('inpAttachments');
const progressBarFill = document.querySelector('progress-bar-fill');
const progressText = document.getElementById('progressText');

   fileInput.addEventListener('change', (event) => {
      const file = event.target.files[0];
      if (!file) return;

       const formData = new FormData();
       formData.append('file', file);

       /*FormData object is created to hold the file data via AJAX.*/
       const xhr = new XMLHttpRequest();
       xhr.open('POST', '/upload-endpoint', true);

       /*XMLHttpRequest object is created and configured to send a POST request to the specified endpoint asynchronously. */
       xhr.upload.addEventListener('progress', (event) => {
           if (event.lengthComputable) {
                const percentComplete = Math.round((event.loaded / event.total) * 100);
                progressBarFill.style.width = `${percentComplete}%`;
                progressText.textContent = `${percentComplete}%`;
           }
       });

       
       xhr.onload = () => {
           if (xhr.status >= 200 && xhr.status <= 300) {
               console.log('Upload successful!');
           } 
           else {
                console.error('Upload failed:', xhr.statusText);
           }
       };

            xhr.onerror = () => {
                console.error('Upload error occurred.');
            };

            xhr.send(formData);
        }); 
