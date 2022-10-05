﻿using DAL.DALInterfaces;
using DAL.FacadeBiz;
using DAL.Utility;
using Dapper;
using Entity;
using Entity.RequestEntity;
using Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    internal class AttendenceRepo : IAttendence
    {
        LogsHandler _logsHandler = new LogsHandler();
        DynamicParams _dynamic = new DynamicParams();
        public List<CheckinResponseModel> CheckIn(AttendanceReqModel attendance)
        {
            _dynamic = new DynamicParams();
            List<CheckinResponseModel> responseLoist = new List<CheckinResponseModel>();
            CheckinResponseModel response = new CheckinResponseModel();

            try
            {
                using (IDbConnection constr = new SqlConnection(Context.ConnectionString))
                {
                    if (constr.State == ConnectionState.Closed)
                        constr.Open();

                    constr.Query<string>("US_ADD_CHECKIN", _dynamic.SetParametersInsertCheckInTime(attendance), commandType: CommandType.StoredProcedure).ToList();

                    responseLoist = GetAttendance(attendance.userId);
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return responseLoist;
        }

        public List<CheckinResponseModel> CheckOut(AttendanceReqModel attendance)
        {
            _dynamic = new DynamicParams();
            List<CheckinResponseModel> responseLoist = new List<CheckinResponseModel>();
            CheckinResponseModel response = new CheckinResponseModel();
            try
            {
                using (IDbConnection constr = new SqlConnection(Context.ConnectionString))
                {
                    if (constr.State == ConnectionState.Closed)
                        constr.Open();

                    constr.Query<string>("US_ADD_CHECKOUT", _dynamic.SetParametersInsertCheckOutTime(attendance), commandType: CommandType.StoredProcedure).ToList();

                    responseLoist = GetAttendance(attendance.userId);
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return responseLoist;
        }

        public List<CheckinResponseModel> GetAttendance(int userId)
        {
            _dynamic = new DynamicParams();
            List<CheckinResponseModel> responseLoist = new List<CheckinResponseModel>();
            CheckinResponseModel response = new CheckinResponseModel();

            try
            {
                using (IDbConnection constr = new SqlConnection(Context.ConnectionString))
                {
                    if (constr.State == ConnectionState.Closed)
                        constr.Open();

                    var attemp = constr.Query<CheckinResponseModel>("UG_GET_ATTENDANCE", _dynamic.SetParametersGettingAttendance(userId), commandType: CommandType.StoredProcedure).ToList();

                    if (attemp != null && attemp.Count() > 0)
                    {
                        string value = attemp[0].attendenceStatus;
                        TimeSpan ts = TimeSpan.Parse(value);

                        foreach (var item in attemp)
                        {
                            response = new CheckinResponseModel();
                            response.checkinDate = item.checkinDate;
                            response.checkinTime = item.checkinTime;
                            response.checkoutTime = item.checkoutTime;
                            response.holidaysCount = item.holidaysCount;
                            response.lateDaysCount = item.lateDaysCount;
                            response.leaveDaysCount = item.leaveDaysCount;
                            response.overTime = item.overTime;
                            response.weekendDaysCount = item.weekendDaysCount;
                            response.userId = item.userId;
                            response.absentDaysCount = item.absentDaysCount;
                            DateTime d = DateTime.Parse(item.checkinTime);
                            string times = d.ToString("HH:mm");
                            response.attendenceStatus = TimeSpan.Parse(times) > ts ? "P/L" : "P";

                            responseLoist.Add(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return responseLoist;
        }
    }
}
