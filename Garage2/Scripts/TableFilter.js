
let searchableTable = document.getElementById('searchableTable');

function TableFilter(filter) {
    let rows = searchableTable.querySelectorAll('tbody tr');
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
