window.renderBarChart = (labels, data) => {
    const canvas = document.getElementById('barChart');
    if (!canvas) return;

    const ctx = canvas.getContext('2d');

    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Average Expense',
                data: data,
                backgroundColor: 'rgba(54, 162, 235, 0.6)'
            }]
        }
    });
};

window.renderPieChart = (labels, data) => {
    const canvas = document.getElementById('pieChart');
    if (!canvas) return;

    const ctx = canvas.getContext('2d');

    if (window.pieChartInstance) {
       
        window.pieChartInstance.data.labels = labels;
        window.pieChartInstance.data.datasets[0].data = data;
        window.pieChartInstance.update();
        return;
    }

    window.pieChartInstance = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: [
                    '#ff6384',
                    '#36a2eb',
                    '#ffce56',
                    '#4bc0c0'
                ]
            }]
        },
        options: {
            responsive: false,
            maintainAspectRatio: false,
            animation: false,
            plugins: {
                legend: {
                    position: 'top'
                }
            }
        }
    });
};
