﻿using PricingWarehouse.DTO;
using System.Data;
using System.Data.SqlClient;

namespace PricingWarehouse.DAO
{
    public class IRSwapDAO:IProducDAO<IRSwapDTO>
    {
        private readonly string _connectionString;
        public IRSwapDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IRSwapDTO GetProductById(int swapId)
        {
            var swapDTO = new IRSwapDTO();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using SqlCommand sqlCommand = new SqlCommand("usp_GetSwapById", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@swapId", SqlDbType.Int).Value = swapId;
                try
                {
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        swapDTO.Currency = reader["currency"].ToString();
                        swapDTO.Notional = Convert.ToDouble(reader["notional"]);
                        swapDTO.FixedRate = Convert.ToDouble(reader["fixed_rate"]);
                        swapDTO.FloatingRateSpread = Convert.ToDouble(reader["floating_rate_spread"]);
                        swapDTO.FloatingRateReference = reader["floating_reference_rate"].ToString();
                        swapDTO.DayCountConvention = reader["day_count_convention"].ToString();
                        swapDTO.PaymentFrequencyMonths = Convert.ToInt32(reader["payment_frequency_months"]);
                        swapDTO.ValuationDate = Convert.ToDateTime(reader["valuation_date"]);
                        swapDTO.StartDate = Convert.ToDateTime(reader["start_date"]);
                        swapDTO.EndDate = Convert.ToDateTime(reader["end_date"]);
                        swapDTO.Price = Convert.ToDouble(reader["price"]);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"GetSwapById-Error : {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return swapDTO;
        }
        
        public int InsertProduct(IRSwapDTO swap)
        {
            var swapId = 0;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("usp_InsertIRSwap", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@currency", SqlDbType.NVarChar).Value = swap.Currency;
                    sqlCommand.Parameters.AddWithValue("@notional", SqlDbType.NVarChar).Value = swap.Notional;
                    sqlCommand.Parameters.AddWithValue("@fixed_rate", SqlDbType.Float).Value = swap.FixedRate;
                    sqlCommand.Parameters.AddWithValue("@floating_reference_rate", SqlDbType.NVarChar).Value = swap.FloatingRateReference;
                    sqlCommand.Parameters.AddWithValue("@floating_rate_spread", SqlDbType.Float).Value = swap.FloatingRateSpread;
                    sqlCommand.Parameters.AddWithValue("@day_count_convention", SqlDbType.Date).Value = swap.DayCountConvention;
                    sqlCommand.Parameters.AddWithValue("@payment_frequency_months", SqlDbType.Int).Value = swap.PaymentFrequencyMonths;
                    sqlCommand.Parameters.AddWithValue("@valuation_date", SqlDbType.Date).Value = swap.ValuationDate;
                    sqlCommand.Parameters.AddWithValue("@start_date", SqlDbType.Date).Value = swap.StartDate;
                    sqlCommand.Parameters.AddWithValue("@end_date", SqlDbType.Date).Value = swap.EndDate;
                    sqlCommand.Parameters.AddWithValue("@price", SqlDbType.Float).Value = swap.Price;

                    var swapIdParam = sqlCommand.Parameters.Add("@swapId", SqlDbType.Int);
                    swapIdParam.Direction = ParameterDirection.Output;
                    swapIdParam.Value = swapId;
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                        swapId = (int)swapIdParam.Value;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"InsertSwap-Error : {ex.Message}");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
                return swapId;
            }
        }






    }
}
