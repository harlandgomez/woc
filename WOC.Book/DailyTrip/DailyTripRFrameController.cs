using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Woc.Book.DailyTrip.BusinessEntity;
using Woc.Book.DailyTripRFrame.Service;
using Woc.Book.DailyTrip.Constant;

using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;


namespace Woc.Book.DailyTripRFrame
{
    internal class DailyTripRFrameController : IOperationController
    {
        DailyTripRFrameService dailyTripRFrameService;
        public DailyTripRFrameController()
        {

        }
        public String UpdateData(IOperation iOperation)
        {
            dailyTripRFrameService = new DailyTripRFrameService();
            return dailyTripRFrameService.UpdateData(iOperation);
        }

        public void SaveData(IOperation iOperation)
        {
            dailyTripRFrameService = new DailyTripRFrameService();
            dailyTripRFrameService.SaveData(iOperation);

        }

        public String DeleteData(IOperation iOperation)
        {
            dailyTripRFrameService = new DailyTripRFrameService();
            return dailyTripRFrameService.DeleteData(iOperation);
        }

        public List<DailyTripsDTO> GetHeadersData()
        {
            dailyTripRFrameService = new DailyTripRFrameService();
            return dailyTripRFrameService.GetHeadersData();
        }

        public List<DriverDetailDTO> GetDetailData(IOperation iOperation)
        {
            DailyTripsDTO dailyDTO = new DailyTripsDTO();
            dailyTripRFrameService = new DailyTripRFrameService();
            dailyDTO = (DailyTripsDTO)iOperation;
            bool hasRow = false;
            int rowCount;

            List<DriverDetailDTO> listDriverDTOs = new List<DriverDetailDTO>();
            DriverDetailDTO driverDTO = new DriverDetailDTO();

            if (dailyDTO.IsSubcon == 1)
            {
                rowCount = Constant.SubConRowCount;
            }
            else
            {
                rowCount = Constant.DriverRowCount;
            }

            DataTable table = dailyTripRFrameService.GetDetailData(dailyDTO.BusNo, dailyDTO.OperationDate, rowCount.ToString());

            int n = 0;
            if (table.DefaultView.Count > 0)
            {
                String busNo = table.Rows[0]["BusNo"].ToString();
                String driverContact = table.Rows[0]["ContactNo"].ToString();
                String driverName = table.Rows[0]["DriverName"].ToString();
                Guid operationID = new Guid(table.Rows[0]["OperationID"].ToString());

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Decimal tripTime = Convert.ToDecimal(Convert.ToDateTime(table.Rows[i]["TripTime"]).ToString("HHmm"));
                    for (int j = n; j < rowCount; j++)
                    {
                        n += 1;
                        hasRow = false;

                        driverDTO.BusNo = busNo;
                        driverDTO.DriverContact = driverContact;
                        driverDTO.DriverName = driverName;
                        driverDTO.OperationID = operationID;
                        if (dailyDTO.IsSubcon == 1)
                        {
                            driverDTO.TripTime = (DateTime)table.Rows[i]["TripTime"];
                            driverDTO.Customer = table.Rows[i]["Customer"].ToString();
                            driverDTO.OperationDetailID = new Guid(table.Rows[i]["OperationDetailID"].ToString());
                            driverDTO.DriverRoute = table.Rows[i]["Route"].ToString();
                            driverDTO.Person = table.Rows[i]["Person"].ToString();
                            driverDTO.Contact = table.Rows[i]["Contact"].ToString();
                            driverDTO.SegmentType = table.Rows[i]["SegmentType"].ToString();

                            hasRow = true;
                        }
                        else
                        {
                            if ((tripTime > -1 && tripTime < 1200 && n < 7) ||
                                (tripTime > 1159 && tripTime < 1800 && n > 8 && n < 16) ||
                                (tripTime > 1759 && tripTime < 2401 && n > 17 && n < rowCount))
                            {
                                driverDTO.TripTime = (DateTime)table.Rows[i]["TripTime"];
                                driverDTO.Customer = table.Rows[i]["Customer"].ToString();
                                driverDTO.OperationDetailID = new Guid(table.Rows[i]["OperationDetailID"].ToString());
                                driverDTO.DriverRoute = table.Rows[i]["Route"].ToString();
                                driverDTO.Person = table.Rows[i]["Person"].ToString();
                                driverDTO.Contact = table.Rows[i]["Contact"].ToString();
                                driverDTO.SegmentType = table.Rows[i]["SegmentType"].ToString();

                                hasRow = true;

                            }
                        }
                        listDriverDTOs.Add(driverDTO);
                        driverDTO = new DriverDetailDTO();

                        if (hasRow == true)
                        {
                            break;
                        }
                    }
                }
                for (int j = n; j < rowCount; j++)
                {
                    driverDTO.BusNo = busNo;
                    driverDTO.DriverContact = driverContact;
                    driverDTO.DriverName = driverName;
                    driverDTO.OperationID = operationID;
                    listDriverDTOs.Add(driverDTO);
                    driverDTO = new DriverDetailDTO();
                }
            }
            else
            {
                for (int j = n; j < rowCount; j++)
                {
                    listDriverDTOs.Add(driverDTO);
                    driverDTO = new DriverDetailDTO();
                }
            }
            return listDriverDTOs;
        }
    }
}
