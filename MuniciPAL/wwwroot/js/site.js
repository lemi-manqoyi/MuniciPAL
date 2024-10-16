document.getElementById('searchForm').addEventListener('submit', function (e) {
      const searchedItem = document.getElementById('inpSearch').value;
      if(!searchedTerm) {
      e.preventDefault();
      alert("Please enter a search term.");
      }
      else {
          document.getElementById('foundItem').value = searchedTerm;
      }                             
});