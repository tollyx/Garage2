
let vehicleTable = document.getElementById('vehicleTable');

function TableFilter(filter) {
    let rows = vehicleTable.querySelectorAll('tbody tr');
    if (rows == null) return;
    filter = filter.toLowerCase();
    for (var i = 0; i < rows.length; i++) {
        let row = rows[i];
        if (row.textContent.toLowerCase().includes(filter)) {
            row.style.display = '';
        }
        else {
            row.style.display = 'none';
        }
    }
}

document.getElementById('filterInput').addEventListener('input', (ev) => {
    TableFilter(ev.target.value);
});
