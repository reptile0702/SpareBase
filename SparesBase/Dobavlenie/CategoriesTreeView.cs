using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    class CategoriesTreeView : TreeView
    {
        public CategoriesTreeView()
        {
                
        }

        public void FillCategories(int organizationId, ContextMenuStrip cmsCategory)
        {
            Nodes.Clear();
            TreeNode root = new TreeNode();

            string where = organizationId != 0 ? "WHERE(OrganizationId=" + organizationId + ")" : "";

            DataTable mainDt = DatabaseWorker.SqlSelectQuery("SELECT id, Name, OrganizationId FROM Main_Category " + where);
            if (mainDt.Rows.Count != 0)
            {
                DataTable subCat1Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_1 " + where);
                DataTable subCat2Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_2 " + where);
                DataTable subCat3Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_3 " + where);
                DataTable subCat4Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_4 " + where);

                // Главная категория
                foreach (DataRow row in mainDt.Rows)
                {
                    Category category = new Category(
                        int.Parse(row.ItemArray[0].ToString()),
                        row.ItemArray[1].ToString(),
                        0,
                        int.Parse(row.ItemArray[2].ToString()));

                    TreeNode newTreeNode = new TreeNode(category.Name);
                    newTreeNode.Tag = category;
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    root.Nodes.Add(newTreeNode);
                }

                // Подкатегория 1
                foreach (DataRow row in subCat1Dt.Rows)
                {
                    Category category = new Category(
                        int.Parse(row.ItemArray[0].ToString()),
                        row.ItemArray[1].ToString(),
                        int.Parse(row.ItemArray[2].ToString()),
                        int.Parse(row.ItemArray[3].ToString()));

                    TreeNode newTreeNode = new TreeNode(category.Name);
                    newTreeNode.Tag = category;
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    int mainId = category.PreviousCategoryId;

                    foreach (TreeNode node in root.Nodes)
                    {
                        Category cat = (Category)node.Tag;
                        if (cat.Id == mainId)
                            node.Nodes.Add(newTreeNode);
                    }
                }

                // Подкатегория 2
                foreach (DataRow row in subCat2Dt.Rows)
                {
                    Category category = new Category(
                        int.Parse(row.ItemArray[0].ToString()),
                        row.ItemArray[1].ToString(),
                        int.Parse(row.ItemArray[2].ToString()),
                        int.Parse(row.ItemArray[3].ToString()));

                    TreeNode newTreeNode = new TreeNode(category.Name);
                    newTreeNode.Tag = category;
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    int sub1Id = category.PreviousCategoryId;

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                        {
                            Category cat = (Category)sub1Node.Tag;
                            if (cat.Id == sub1Id)
                                sub1Node.Nodes.Add(newTreeNode);
                        }
                }

                // Подкатегория 3
                foreach (DataRow row in subCat3Dt.Rows)
                {
                    Category category = new Category(
                        int.Parse(row.ItemArray[0].ToString()),
                        row.ItemArray[1].ToString(),
                        int.Parse(row.ItemArray[2].ToString()),
                        int.Parse(row.ItemArray[3].ToString()));

                    TreeNode newTreeNode = new TreeNode(category.Name);
                    newTreeNode.Tag = category;
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    int sub2Id = category.PreviousCategoryId;

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                            foreach (TreeNode sub2Node in sub1Node.Nodes)
                            {
                                Category cat = (Category)sub2Node.Tag;
                                if (cat.Id == sub2Id)
                                    sub2Node.Nodes.Add(newTreeNode);
                            }
                }

                // Подкатегория 4
                foreach (DataRow row in subCat4Dt.Rows)
                {
                    Category category = new Category(
                        int.Parse(row.ItemArray[0].ToString()),
                        row.ItemArray[1].ToString(),
                        int.Parse(row.ItemArray[2].ToString()),
                        int.Parse(row.ItemArray[3].ToString()));

                    TreeNode newTreeNode = new TreeNode(category.Name);
                    newTreeNode.Tag = category;
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    int sub3Id = category.PreviousCategoryId;

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                            foreach (TreeNode sub2Node in sub1Node.Nodes)
                                foreach (TreeNode sub3Node in sub2Node.Nodes)
                                {
                                    Category cat = (Category)sub3Node.Tag;
                                    if (cat.Id == sub3Id)
                                        sub3Node.Nodes.Add(newTreeNode);
                                }
                }

                // Добавление нодов в TreeView
                foreach (TreeNode node in root.Nodes)
                    Nodes.Add(node);

                // Сортировка по алфавиту
                Sort();

                // Выделение первого нода
                if (Nodes.Count != 0)
                    SelectedNode = Nodes[0];
            }
        }

        // Возвращает массив категорий сформированный по полному пути выделенного нода в TreeView
        public int[] FormCategories()
        {
            int[] categories = new int[5];
            List<int> cats = new List<int>();
            TreeNode parent = SelectedNode;

            do
            {
                Category category = (Category)parent.Tag;
                cats.Add(category.Id);
                parent = parent.Parent;
            }
            while (parent != null);

            cats.Reverse();
            for (int i = 0; i < categories.Length; i++)
            {
                if (i > cats.Count - 1)
                    break;
                else
                    categories[i] = cats[i];
            }

            return categories;
        }

        // Возвращает массив категорий сформированный по полному пути нода
        public int[] FormCategories(TreeNode node)
        {
            int[] categories = new int[5];
            List<int> cats = new List<int>();
            TreeNode parent = node;

            do
            {
                Category category = (Category)parent.Tag;
                cats.Add(category.Id);
                parent = parent.Parent;
            }
            while (parent != null);

            cats.Reverse();
            for (int i = 0; i < categories.Length; i++)
            {
                if (i > cats.Count - 1)
                    break;
                else
                    categories[i] = cats[i];
            }

            return categories;
        }

        public Category[] GetCategories()
        {
            List<Category> categories = new List<Category>();
            TreeNode parent = SelectedNode;

            int categoryCounter = 0;
            do
            {
                Category category = (Category)parent.Tag;
                categories.Add(category);
                parent = parent.Parent;
                categoryCounter++;
            }
            while (parent != null);

            Category[] reversedCategories = new Category[5];

            categories.Reverse();

            for (int i = 0; i < categories.Count; i++)
            {
                if (i > categories.Count - 1)
                    break;
                else
                    reversedCategories[i] = categories[i];
            }

            return reversedCategories;
        }
    }
}
