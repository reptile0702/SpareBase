using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class CitiesForm : Form
    {
        public CitiesForm()
        {
            InitializeComponent();
            FillCities();
        }

        // Заполнение городов
        private void FillCities()
        {
            dgvCities.Rows.Clear();

            DataTable cities = DatabaseWorker.SqlSelectQuery("SELECT * FROM Cities");
            foreach (DataRow row in cities.Rows)
                dgvCities.Rows.Add(row.ItemArray[0], row.ItemArray[1]);
        }
    }
}
