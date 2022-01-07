using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Woc.Book.Base.Presenter;
using Woc.Book.Base;
using Woc.Book.Base.Constant;

using Woc.Book.DailyTripRFrame.Presenter;
using Woc.Book.DailyTrip.BusinessEntity;
using System.Web.UI.HtmlControls;
namespace WOC.Book.Report
{
    public partial class SubconExportXLS : System.Web.UI.Page
    {
        DailyTripRFramePresenter dailyTripPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindings();
            }
        }

        #region Helper Methods

        private void DataBindings()
        {

            dailyTripPresenter = new DailyTripRFramePresenter();
            List<DriverDetailDTO> tripDetailList;
            List<DailyTripsDTO> tripHeaderList = dailyTripPresenter.GetHeadersData();

            //from list
            TableRow row;
            TableCell cell;

            //main table
            TableRow mainRow;
            TableCell mainLeftCell = null;
            TableCell mainRightCell = null;
            TableCell mainCenterCell = null;

            Int16 currDriverCount = 0;

            foreach (DailyTripsDTO tripHeader in tripHeaderList)
            {
                if (tripHeader.IsSubcon == 0)
                {
                    continue;
                }

                Table subTable = new Table();
                subTable.CellPadding = 0;
                subTable.CellSpacing = 0;
                subTable.Font.Name = "Tahoma";

                row = new TableRow();
                cell = new TableCell();
                currDriverCount += 1;
                cell.Text = tripHeader.BusNo;
                cell.Width = Unit.Pixel(40);
                cell.BorderWidth = Unit.Pixel(1);

                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = tripHeader.Driver + " " + tripHeader.Contact;
                cell.Width = Unit.Pixel(320);
                cell.BorderWidth = Unit.Pixel(1);
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "Customer";
                cell.Width = Unit.Pixel(60);
                cell.BorderWidth = Unit.Pixel(1);
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "Person";
                cell.Width = Unit.Pixel(60);
                cell.BorderWidth = Unit.Pixel(1);
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "Contact";
                cell.Width = Unit.Pixel(60);
                cell.BorderWidth = Unit.Pixel(1);
                row.Cells.Add(cell);
                row.Attributes.Add("class", "headerRow");

                subTable.Rows.Add(row);

                tripHeader.OperationDate = UtilityController.StringToDate(Request.QueryString["TripDate"].ToString());
                tripDetailList = dailyTripPresenter.GetDetailData(tripHeader);

                String prevTime = String.Empty;
                String currTime = String.Empty;
                DateTime prevTimeDate = DateTime.MinValue;

                foreach (DriverDetailDTO tripDetail in tripDetailList)
                {
                    row = new TableRow();

                    cell = new TableCell();
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    currTime = tripDetail.TripTime.ToString("H:mm");

                    if (!currTime.Equals(prevTime) && !currTime.Equals("0:00"))
                    {
                        cell.Text = tripDetail.TripTime.ToString("H:mm");

                        if (tripDetail.TripTime < prevTimeDate.AddHours(2))
                        {
                            cell.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        cell.Text = "&nbsp;";
                    }
                    cell.BorderWidth = Unit.Pixel(1);
                    row.Cells.Add(cell);
                    prevTime = tripDetail.TripTime.ToString("H:mm");
                    prevTimeDate = tripDetail.TripTime;

                    cell = new TableCell();
                    cell.Text = tripDetail.DriverRoute;
                    cell.BorderWidth = Unit.Pixel(1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = tripDetail.Customer;
                    cell.BorderWidth = Unit.Pixel(1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = tripDetail.Person;
                    cell.BorderWidth = Unit.Pixel(1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = tripDetail.Contact;
                    cell.BorderWidth = Unit.Pixel(1);
                    row.Cells.Add(cell);
                    row.Attributes.Add("class", "itemRow");
                    subTable.Rows.Add(row);
                }

                if ((currDriverCount % 3) == 0)
                {
                    mainRow = new TableRow();

                    //left table
                    mainRow.Cells.Add(mainLeftCell);

                    ////Separator cell
                    cell = new TableCell();
                    cell.Text = "&nbsp;";
                    mainRow.Cells.Add(cell);

                    //Center table
                    mainRow.Cells.Add(mainCenterCell);

                    ////Separator cell
                    cell = new TableCell();
                    cell.Text = "&nbsp;";
                    mainRow.Cells.Add(cell);

                    //right table
                    mainRightCell = new TableCell();
                    mainRightCell.Controls.Add(subTable);
                    mainRow.Cells.Add(mainRightCell);

                    //add 3 cells
                    tblMain.Rows.Add(mainRow);

                    // Separator Row
                    row = new TableRow();
                    cell = new TableCell();
                    cell.Text = "&nbsp;";
                    row.Cells.Add(cell);
                    row.Attributes.Add("class", "separateRow");

                    tblMain.Rows.Add(row);
                }
                else
                {
                    if ((currDriverCount % 2) == 0)
                    {
                        mainCenterCell = new TableCell();
                        mainCenterCell.Controls.Add(subTable);
                    }
                    else
                    {
                        mainLeftCell = new TableCell();
                        mainLeftCell.Controls.Add(subTable);
                    }

                    if (currDriverCount == tripHeaderList.Count)
                    {
                        mainRow = new TableRow();
                        mainRow.Cells.Add(mainLeftCell);

                        ////Separator cell
                        cell = new TableCell();
                        cell.Text = "&nbsp;";
                        mainRow.Cells.Add(cell);

                        //Center table
                        mainRow.Cells.Add(mainCenterCell);

                        ////Separator cell
                        cell = new TableCell();
                        cell.Text = "&nbsp;";
                        mainRow.Cells.Add(cell);

                        tblMain.Rows.Add(mainRow);
                    }

                    if ((currDriverCount - 1) == tripHeaderList.Count)
                    {
                        mainRow = new TableRow();
                        mainRow.Cells.Add(mainLeftCell);
                        tblMain.Rows.Add(mainRow);
                    }

                }
            }

        }

        #endregion
    }
}