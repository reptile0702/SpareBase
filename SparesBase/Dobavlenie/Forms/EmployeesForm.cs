﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBase.Forms
{
    public partial class EmployeesForm : Form
    {
        public EmployeesForm()
        {
            InitializeComponent();
            FillEmployees();
        }

        private void FillEmployees()
        {
            DataTable employees = DatabaseWorker.SqlSelectQuery("SELECT a.id, a.FirstName, a.LastName, a.SecondName, a.Login, c.City, a.Phone, a.Email, a.Admin  FROM Accounts a LEFT JOIN Cities c ON c.id=a.CityId WHERE(OrganizationId=" + EnteredUser.OrganizationId + ")");
            foreach (DataRow row in employees.Rows)
            {
                Account account = new Account(
                    int.Parse(row.ItemArray[0].ToString()),
                    row.ItemArray[1].ToString(),
                    row.ItemArray[2].ToString(),
                    row.ItemArray[3].ToString(),
                    row.ItemArray[4].ToString(),
                    row.ItemArray[5].ToString(),
                    row.ItemArray[6].ToString(),
                    row.ItemArray[7].ToString(),
                    row.ItemArray[8].ToString() == "1" ? true: false);

                dgv.Rows.Add(account.LastName, account.FirstName, account.SecondName);
                dgv.Rows[dgv.Rows.Count - 1].Tag = account;
                
            }
            
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            AccountCardForm acf = new AccountCardForm((Account)dgv.Rows[e.RowIndex].Tag);
            acf.ShowDialog();

        }
    }
}