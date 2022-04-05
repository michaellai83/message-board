using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPagetest01
{
    public partial class GVpage01 : System.Web.UI.UserControl
    {
        //總共幾筆資料
        public int totalItems { get; set; }
        //一頁幾筆資料
        public int limit { get; set; }
        //作用頁面完整網頁名稱
        public string targetPage { get; set; }

        #region "用正規式判斷是否為數字"
        /// <summary>
        /// 用正規式判斷是否為數字
        /// </summary>
        /// <param name="inputData">輸入字串</param>
        /// <returns>bool</returns>
        bool IsNumber(string inputData)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(inputData, "^[0-9]+$");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ShowPageControls()
        {
            //清空分頁控制項
            litpage.Text = "";
            //預設第一頁
            int page = 1;
            //如果網址有傳值
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                //傳值為數字
                if (IsNumber(Request["page"]))
                {
                    //修改當前頁碼
                    page = Convert.ToInt16(Request["page"]);
                }
            }
            if(totalItems == 0)
            {
                return;
            }
            if(limit == 0)
            {
                return;
            }
            //確認當前頁面檔案名稱非 NULL 在 ?? 左側非 null則不變 左側式 null則傳回右側結果
            targetPage = targetPage ?? System.IO.Path.GetFileName(Request.PhysicalPath);
            //渲染分頁控制項  鄰近頁 adjacents 參數不建議設太大 可能導致換行
            litpage.Text = getPaginationString(page, totalItems, limit, 2, targetPage);
        }
        #region "產生分頁空制項"
        ///<summary>
        ///產生分頁控制項
        ///</summary>
        ///<param name="page">目前第幾頁</param>
        ///<param name="totalItems">共有幾筆</param>
        ///<param name="limit">一頁幾筆資料</param>
        ///<param name="adjacents">鄰近頁左右各幾筆 兩側隱藏時只顯示當前頁左右個幾頁 不可為 0 值設太大可能導致換行 建議值為 2</param>
        ///<param name="targetPage">當前頁面檔案名稱</param>
        ///<returns>回傳HTML標籤字串</returns>
        public static string getPaginationString(int page, int totalItems, int limit, int adjacents, string targetPage)
        {
            //判斷預設網頁有無帶有傳值用 如果有出現 ? 表示 已有傳參數 就在後面加 & 加掛 如無則補加 ? 
            //預設在檔名後加問號
            targetPage = targetPage.IndexOf('?') != -1 ? targetPage + "&" : targetPage + "?";
            //前一頁 = 目前頁面-1
            int prev = page - 1;
            //下一頁 = 目前頁面 +1
            int nextPage = page + 1;
            //網頁總數值 = 總資料筆數/ 每頁幾筆
            Double value = Convert.ToDouble((decimal)totalItems / limit);
            //最末頁(總頁數) = 總頁數數值無條件進位成整數
            int lastpage = Convert.ToInt16(Math.Ceiling(value));
            //倒豎第二頁 = 最末頁-1
            int secondLast = lastpage - 1;
            //邏輯判斷共用參數
            //int commonParameter = 3 + (adjacents * 2); //不可修改:"3"代表當前頁 + 首或末兩頁, "2"代表左右側頁
            //建立分頁HTML 字串邏輯
            StringBuilder paginationBuilder = new StringBuilder();
            //超過1頁才顯示分頁控制項
            if(lastpage > 1)
            {
                //共計幾筆資料 HTML
                paginationBuilder.Append("<div class = \"pagination\">Total <span style=\"color:red\">" + totalItems + "</span> data.");
                //上一頁HTML 目前頁面大於1 則啟用連結 否則就禁用
                paginationBuilder.Append(page > 1 ? $"<a href=\"{targetPage}page={prev}\"> <<< </a>" : "<span class=\"disabled\"> <<< </span>");
                //頁碼選項 HTML 邏輯判斷

                //總頁數 不多於 (邏輯判斷共用參數 + (3= 代表當前頁+首或末兩頁) 就不隱藏頁碼
                if(lastpage < 7 +(adjacents*2))
                //if (lastpage <= commonParameter + 3)
                {
                    for(int counter = 1; counter <= lastpage; counter++)
                    {
                        //counter 等於當前頁面則不加入連結 否則就加入連結
                        paginationBuilder.Append(counter == page ? $"<span class=\"current\">{counter}</span>" : $"<a href=\"{targetPage}page={counter}\">{counter}</a>");

                    }
                }
                //執行隱藏頁碼
                else
                {
                    //指隱藏右側頁碼
                    if(page < 1+(adjacents*3))
                    //if(page < commonParameter)
                    {
                        for(int counter =1; counter <= (3+(adjacents*2));counter++)
                        //for(int counter = 1; counter <= commonParameter; counter++)
                        {
                            paginationBuilder.Append(counter == page ? $"<span class=\"current\">{counter}</span>" : $"<a href=\"{targetPage}page={counter}\">{counter}</a>");

                        }
                        //之後的頁碼用..省略
                        paginationBuilder.Append("...");
                        //加入倒數第二頁
                        paginationBuilder.Append($"<a href=\"{targetPage}page={secondLast}\">{secondLast}</a>");
                        // paginationBuilder.Append(string.Format("<a href=\"{0}page={1}\">{1}</a>", targetPage, secondLast));
                        //加入最末頁
                        paginationBuilder.Append($"<a href=\"{targetPage}page={lastpage}\">{lastpage}</a>");
                        //paginationBuilder.Append(string.Format("<a href=\"{0}page={1}\">{1}</a>", targetPage, lastpage));

                    }
                    //中間頁碼 隱藏兩側頁碼
                    else if(page >(adjacents*2) && page <(lastpage - (adjacents*2)))
                    //else if(page >= commonParameter && page <= lastpage - commonParameter)
                    {
                        //加入第一頁+第二頁及...省略頁碼
                        paginationBuilder.Append($"<a href=\"{targetPage}page=1\">1</a>");
                        paginationBuilder.Append($"<a href=\"{targetPage}page=2\">2</a>");
                        //paginationBuilder.Append(string.Format("<a href=\"{0}page=1\">1</a>", targetPage));
                        //paginationBuilder.Append(string.Format("<a href=\"{0}page=2\">2</a>", targetPage));
                        for(int counter = (page-adjacents);counter <= (page+adjacents);counter++)
                        //for(int counter = page-adjacents; counter <= page+adjacents; counter++)
                        {
                            //從當前頁的左側鄰近頁到右側鄰近頁正常添加頁碼(當前頁不佳連結)
                            paginationBuilder.Append(counter == page ? $"<span class=\"current\">{counter}</span>" : $"<a href =\"{targetPage}page={counter}\">{counter}</a>");
                           
                        }
                        //之後的頁碼用...省略 加入倒數第二頁 及最末頁
                        paginationBuilder.Append("...");
                        paginationBuilder.Append($"<a href =\"{targetPage}page={secondLast}\">{secondLast}</a>");
                        paginationBuilder.Append($"<a href =\"{targetPage}page={secondLast}\">{secondLast}</a>");
                        //paginationBuilder.Append(string.Format("<a href =\"{0}page={1}\">{1}</a>", targetPage, secondLast));
                        //paginationBuilder.Append(string.Format("<a href =\"{0}page={1}\">{1}</a>", targetPage, lastpage));
                    }
                    ///指隱藏左側頁碼
                    else {
                        //加入第一頁+第二頁及..省略頁碼
                        paginationBuilder.Append($"<a href =\"{targetPage}page=1\">1</a>");
                        paginationBuilder.Append($"<a href =\"{targetPage}page=2\">2</a>");
                        paginationBuilder.Append("...");
                        for(int counter = (lastpage -(3+(adjacents*2)));counter <=lastpage;counter++)
                        //for(int counter = lastpage-commonParameter; counter <= lastpage; counter++)
                        {
                            paginationBuilder.Append(counter == page ? $"<span class=\"current\">{counter}</span>" : $"<a href=\"{targetPage}page={counter}\">{counter}</a>");
                        }
                    }
                }
                //下一頁的HTML 內容 目前頁面小於最末頁 則啟用連結 否則就禁用
                paginationBuilder.Append(page < lastpage ? $"<a href =\"{targetPage}page={nextPage}\"> >>> </a>" : "<span class=\"disabled\"> >>> </sapn>");
                paginationBuilder.Append("<div>\r\n");
            }
            return paginationBuilder.ToString();
            
        }
        #endregion
    }
}