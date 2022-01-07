using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;
using Woc.Book.Contract.Service;
using Woc.Book.Contract.BusinessEntity;

namespace Woc.Book.Contract
{
    internal class ContractController : INewBookingController
    {
        public String SaveData(INewBookEntity iNewBookEntity)
        {
            ContractService contractService = new ContractService();
            ContractSchedules contractSchedules;
            Contracts contracts = (Contracts) iNewBookEntity;
            List<ContractSchedules> ListContractSchedules = new List<ContractSchedules>();

            DateTime startDate = contracts.StartDate;
            DateTime stopDate = contracts.StopDate;

            Guid contractID = new Guid(contractService.SaveData(iNewBookEntity));

            for(DateTime date = startDate; date.Date <= stopDate.Date; date = date.AddDays(1))
            {
                contractSchedules = new ContractSchedules();
                bool hasTime = false;
                if (date.DayOfWeek.ToString() == "Monday" && contracts.Monday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartMonday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartMonday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndMonday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndMonday.Substring(2, 2)));
                }
                else if(date.DayOfWeek.ToString() == "Tuesday" && contracts.Tuesday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartTuesday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartTuesday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndTuesday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndTuesday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Wednesday" && contracts.Wednesday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartWednesday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartWednesday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndWednesday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndWednesday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Thursday" && contracts.Thursday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartThursday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartThursday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndThursday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndThursday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Friday" && contracts.Friday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartFriday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartFriday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndFriday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndFriday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Saturday" && contracts.Saturday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartSaturday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartSaturday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndSaturday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndSaturday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Saturday" && contracts.Saturday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartSaturday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartSaturday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndSaturday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndSaturday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Sunday" && contracts.Sunday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartSunday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartSunday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndSunday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndSunday.Substring(2, 2)));
                }

                if (hasTime)
                {
                    contractSchedules.ContractID = contractID;
                    contractSchedules.ScheduleDate = date;
                    ListContractSchedules.Add(contractSchedules);
                }
            }

            return contractService.SaveScheduleData(ListContractSchedules); 
        }

        public List<Contracts> SearchData(INewBookEntity iBusinessEntity)
        {
            ContractService ContractService = new ContractService();
            Contracts contracts = new Contracts();
            contracts = (Contracts)iBusinessEntity;
            string strParemeter = String.Empty;
            if (!String.IsNullOrEmpty(contracts.Agent))
            {
                strParemeter = "A.Agent like '%" + contracts.Agent + "%'";
            }
            else if (!String.IsNullOrEmpty(contracts.BookingCode))
            {
                strParemeter = "C.BookingCode like '%" + contracts.BookingCode + "%'";
            }
            else
            {
                strParemeter = "1=1";
            }

            strParemeter = strParemeter + " and C.[Delete] <> 'Y'";

            if (contracts.ActiveStatus == 1)
            {
                strParemeter = strParemeter + " and C.StopDate > GetDate() ";
            }
            else if (contracts.ActiveStatus == 0)
            {
                strParemeter = strParemeter + " and GetDate() > C.StopDate ";
            }
            
            return ContractService.SearchData(strParemeter);
        }

        public Contracts GetUpdateData(String id)
        {
            String strParemeter = "ContractId = '" + id + "'";
            ContractService contractService = new ContractService();
            return contractService.GetData(strParemeter);
        }

        public String UpdateData(INewBookEntity iNewBookEntity)
        {
            ContractService contractService = new ContractService();
            ContractSchedules contractSchedules;
            Contracts contracts = (Contracts)iNewBookEntity;
            List<ContractSchedules> ListContractSchedules = new List<ContractSchedules>();

            DateTime startDate = contracts.StartDate;
            DateTime stopDate = contracts.StopDate;

            Guid contractID = new Guid(contractService.UpdateData(iNewBookEntity));
            String deleteMessage = contractService.DeleteContractSchedules(contractID.ToString());

            for (DateTime date = startDate; date.Date <= stopDate.Date; date = date.AddDays(1))
            {
                contractSchedules = new ContractSchedules();
                bool hasTime = false;
                if (date.DayOfWeek.ToString() == "Monday" && contracts.Monday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartMonday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartMonday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndMonday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndMonday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Tuesday" && contracts.Tuesday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartTuesday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartTuesday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndTuesday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndTuesday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Wednesday" && contracts.Wednesday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartWednesday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartWednesday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndWednesday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndWednesday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Thursday" && contracts.Thursday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartThursday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartThursday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndThursday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndThursday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Friday" && contracts.Friday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartFriday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartFriday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndFriday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndFriday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Saturday" && contracts.Saturday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartSaturday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartSaturday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndSaturday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndSaturday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Saturday" && contracts.Saturday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartSaturday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartSaturday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndSaturday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndSaturday.Substring(2, 2)));
                }
                else if (date.DayOfWeek.ToString() == "Sunday" && contracts.Sunday == true)
                {
                    hasTime = true;
                    contractSchedules.StartTime = date.AddHours(Convert.ToInt32(contracts.StartSunday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.StartSunday.Substring(2, 2)));
                    contractSchedules.EndTime = date.AddHours(Convert.ToInt32(contracts.EndSunday.Substring(0, 2))).AddMinutes(Convert.ToInt32(contracts.EndSunday.Substring(2, 2)));
                }

                if (hasTime)
                {
                    contractSchedules.ContractID = contractID;
                    contractSchedules.ScheduleDate = date;
                    ListContractSchedules.Add(contractSchedules);
                }
            }

            return contractService.SaveScheduleData(ListContractSchedules); 
        }

        public String DeleteData(INewBookEntity iNewBookEntity)
        {
            return "";
        }


    }
}
