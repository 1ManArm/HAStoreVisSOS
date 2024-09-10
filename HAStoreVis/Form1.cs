using System;
using System.Data.SQLite;
using HAStoreVis;

namespace HAStoreVis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            string result = DBWork.CreateStoreDB("Store.db");
            MessageBox.Show(result);
        }

        public void btnInitializeData_Click(object sender, EventArgs e)
        {
            DBWork.InitializeData("Store.db");
            MessageBox.Show("������ ����������������");
        }

        public void btnCountCustomers_Click(object sender, EventArgs e)
        {
            int count = DBWork.CountCustomersWhoBoughtWatchesIn2023("Store.db");
            MessageBox.Show($"���������� �����������, �������� ���� � 2023 ����: {count}");
        }

        public void btnAverageAge_Click(object sender, EventArgs e)
        {
            double averageAge = DBWork.AverageAgeOfCustomersWhoBoughtPendantOnFebruary14("Store.db");
            MessageBox.Show($"������� ������� ����������� ������� 14 �������: {averageAge}");
        }

        public void btnAverageCheck_Click(object sender, EventArgs e)
        {
            decimal averageCheck = DBWork.AverageCheckOnDecember31("Store.db");
            MessageBox.Show($"������� ��� ������� 31 �������: {averageCheck}");
        }
    }
}

