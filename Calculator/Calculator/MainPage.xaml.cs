using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Calculator
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        //decimal：保存帶正負號的 128 位元(16 位元組) 值
        public decimal firstNum;
        public string operatorName;
        public bool isOperatorClicked;
        //數字鍵
        public void BtnNum_Clicked(object sender,EventArgs e)
        {
            var button = sender as Button;
            //如果螢幕數字是0或運算符號已點選
            if(Result.Text == "0"||isOperatorClicked)
            {
                isOperatorClicked = false;
                Result.Text = button.Text;
            }
            else
            {
                Result.Text += button.Text;
            }
        }
        //刪除鍵
        public void BtnDelete_Clicked(object sender,EventArgs e)
        {
            string num = Result.Text;
            if(num != "0")
            {
                //扣除一個數字
                num = num.Remove(num.Length - 1, 1);//後面的1為刪除的字元數
                //如果是空白
                if (string.IsNullOrEmpty(num))
                {
                    Result.Text = "0";
                }
                else
                {
                    Result.Text = num;
                }
            }
        }
        //運算符號鍵
        public void BtnOperation_Clicked(object sender,EventArgs e)
        {
            //共用click 看按下哪個button
            //var是一種資料型態 C#會自動判斷後方的格式，現在就是Button型態
            var button = sender as Button;

            var yy = 56.7;
            Console.WriteLine(yy.GetType());//輸出Double
            //運算符號已經點選
            isOperatorClicked = true;
            operatorName = button.Text;//紀錄按鈕的文字
            firstNum = Convert.ToDecimal(Result.Text);
        }
        //等於的按鍵
        public void BtnEqual_Clicked(object sender,EventArgs e)
        {
            try
            {
                //Result.Text轉成10進位
                decimal secondNum = Convert.ToDecimal(Result.Text);
                //計算找出最後的值
                string finalResult = Calculate(firstNum, secondNum).ToString("0.####");
                Result.Text = finalResult;
            }
            catch(Exception el)
            {
                //錯誤警示
                DisplayAlert("Error", el.Message, "OK");
            }
        }
        //將輸入 對應的運算符號進行運算
        public decimal Calculate(decimal firstNum,decimal sencondNum)
        {
            decimal result = 0;
            //判斷operatorName是甚麼符號
            switch (operatorName)
            {
                //如果碰到 +
                case "+":
                    result = firstNum + sencondNum;
                    break;
                //如果碰到 -
                case "-":
                    result = firstNum - sencondNum;
                    break;
                //如果碰到 x
                case "x":
                    result = firstNum * sencondNum;
                    break;
                //如果碰到 /
                case "/":
                    result = firstNum / sencondNum;
                    break;
            }
            return result;
        }
        //C：清除所有值歸0
        public void ClearAll(System.Object sender, System.EventArgs e)
        {
            Result.Text = "0";
            isOperatorClicked = false;
            //把數字變0
            firstNum = 0;
        }
    }

}
