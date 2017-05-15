using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillTreeView();
        }


        // Заполнение TreeView категориями из базы
        private void FillTreeView()
        {
            string path = "";
            if (treeView.SelectedNode != null)
                path = treeView.SelectedNode.FullPath.ToUpper();

            treeView.Nodes.Clear();
            TreeNode root = new TreeNode();

            DataTable mainDt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Main_Category");
            if (mainDt.Rows.Count != 0)
            {
                DataTable subCat1Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_1");
                DataTable subCat2Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_2");
                DataTable subCat3Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_3");
                DataTable subCat4Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_4");

                // MainCat
                foreach (DataRow row in mainDt.Rows)
                {
                    TreeNode newTreeNode = new TreeNode(row.ItemArray[1].ToString());
                    newTreeNode.Tag = row.ItemArray[0];
                    root.Nodes.Add(newTreeNode);
                }

                // SubCat1
                foreach (DataRow row in subCat1Dt.Rows)
                {
                    TreeNode newTreeNode = new TreeNode(row.ItemArray[1].ToString());
                    newTreeNode.Tag = row.ItemArray[0];
                    string mainId = row.ItemArray[2].ToString();

                    foreach (TreeNode node in root.Nodes)
                        if (node.Tag.ToString() == mainId)
                            node.Nodes.Add(newTreeNode);
                }

                // SubCat2
                foreach (DataRow row in subCat2Dt.Rows)
                {
                    TreeNode newTreeNode = new TreeNode(row.ItemArray[1].ToString());
                    newTreeNode.Tag = row.ItemArray[0];
                    string sub1Id = row.ItemArray[2].ToString();

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                            if (sub1Node.Tag.ToString() == sub1Id)
                                sub1Node.Nodes.Add(newTreeNode);
                }

                // SubCat3
                foreach (DataRow row in subCat3Dt.Rows)
                {
                    TreeNode newTreeNode = new TreeNode(row.ItemArray[1].ToString());
                    newTreeNode.Tag = row.ItemArray[0];
                    string sub2Id = row.ItemArray[2].ToString();

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                            foreach (TreeNode sub2Node in sub1Node.Nodes)
                                if (sub2Node.Tag.ToString() == sub2Id)
                                    sub2Node.Nodes.Add(newTreeNode);
                }

                // SubCat4
                foreach (DataRow row in subCat4Dt.Rows)
                {
                    TreeNode newTreeNode = new TreeNode(row.ItemArray[1].ToString());
                    newTreeNode.Tag = row.ItemArray[0];
                    string sub3Id = row.ItemArray[2].ToString();

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                            foreach (TreeNode sub2Node in sub1Node.Nodes)
                                foreach (TreeNode sub3Node in sub2Node.Nodes)
                                    if (sub3Node.Tag.ToString() == sub3Id)
                                        sub3Node.Nodes.Add(newTreeNode);
                }

                // Добавление нодов в TreeView
                foreach (TreeNode node in root.Nodes)
                    treeView.Nodes.Add(node);

                //SelectNodeByPath(treeView.Nodes, path);
            }
        }

        // Заполнение DataGridView предметами по выделенным категориям в TreeView
        public void FillDataGridView()
        {
            string[] selectedCategories = FormCategories();

            // Формирование условия WHERE
            string where = "WHERE (";
            for (int i = 0; i < selectedCategories.Length; i++)
            {
                if (i == 0) where += "Main_Category_Id=(SELECT id FROM Main_Category WHERE(Name='" + selectedCategories[i] + "'))";
                if (i == 1) where += " AND Sub_Category_1_Id=(SELECT id FROM Sub_Category_1 WHERE(Name='" + selectedCategories[i] + "'))";
                if (i == 2) where += " AND Sub_Category_2_Id=(SELECT id FROM Sub_Category_2 WHERE(Name='" + selectedCategories[i] + "'))";
                if (i == 3) where += " AND Sub_Category_3_Id=(SELECT id FROM Sub_Category_3 WHERE(Name='" + selectedCategories[i] + "'))";
                if (i == 4) where += " AND Sub_Category_4_Id=(SELECT id FROM Sub_Category_4 WHERE(Name='" + selectedCategories[i] + "'))";
            }
            where += ")";

            // Выполнение запроса
            DataTable items = DatabaseWorker.SqlSelectQuery("SELECT id, Item_Name, Seller_Id, Purchase_Price, Retail_Price, Wholesale_Price, Service_Price, Storage, Note, Quantity, Upload_Date FROM Items " + where);

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Наименование");
            dt.Columns.Add("Поставщик");
            dt.Columns.Add("Закупка");
            dt.Columns.Add("Розница");
            dt.Columns.Add("Мелкий опт");
            dt.Columns.Add("Сервисы");
            dt.Columns.Add("Хранение");
            dt.Columns.Add("Примечание");
            dt.Columns.Add("Количество");
            dt.Columns.Add("Дата добавления");

            for (int i = 0; i < items.Rows.Count; i++)
                dt.Rows.Add().ItemArray = items.Rows[i].ItemArray;

            dgv.DataSource = dt;
        }

        // Возвращает массив категорий сформированный по полному пути выделенного нода в TreeView
        private string[] FormCategories()
        {
            return treeView.SelectedNode.FullPath.Split('\\');
        }


        
      
        

        private void AddingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Вписать выделенный ID предмета
            //AddForm form = new AddForm();
            //form.Show();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillDataGridView();
        }

        private void cmsAddItem_Click(object sender, EventArgs e)
        {
            EditForm form = new EditForm(FormCategories());
            form.Show();
            FillDataGridView();
        }

        private void cmsEditItem_Click(object sender, EventArgs e)
        {

        }

        private void cmsDeleteItem_Click(object sender, EventArgs e)
        {

        }
    }
}
