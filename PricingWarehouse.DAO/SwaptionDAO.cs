using System.Data;
using System.Data.SqlClient;

namespace PricingWarehouse.DAO
{
    public interface ISwaptionDAO
    {
        int InsertSwaption(ISwaptionDTO swaption);
        ISwaptionDTO GetSwaptionById(int swaptionId);
    }
    public class EuropeanSwaptionDAO:ISwaptionDAO
    {
        private readonly string _connectionString;
        public EuropeanSwaptionDAO(string connectionString)
            {
            _connectionString = connectionString;
            }

        public ISwaptionDTO GetSwaptionById(int swaptionId)
        {
            var swaptionDTO = new EuropeanSwaptionDTO();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using SqlCommand sqlCommand = new SqlCommand("usp_GetEuropeanSwaptionById", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@swaptionId", SqlDbType.Int).Value = swaptionId;
                try
                {
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        swaptionDTO.OptionType = reader["option_type"].ToString();
                        swaptionDTO.SettlementType = reader["settlement_type"].ToString();
                        swaptionDTO.OptionEffectiveDate = Convert.ToDateTime(reader["option_effective_date"]);
                        swaptionDTO.OptionExpirationDate = Convert.ToDateTime(reader["option_expiration_date"]);
                        swaptionDTO.OptionValuationDate = Convert.ToDateTime(reader["option_valuation_date"]);
                        swaptionDTO.SwapStartDate = Convert.ToDateTime(reader["swap_start_date"]);
                        swaptionDTO.SwapEndDate = Convert.ToDateTime(reader["swap_end_date"]);
                        swaptionDTO.OptionPrice = Convert.ToDouble(reader["option_price"]);
                        swaptionDTO.StrikeRate = Convert.ToDouble(reader["strike_rate"]);
                        swaptionDTO.FloatRateReference = reader["float_rate_reference"].ToString();
                        swaptionDTO.Currency = reader["currency"].ToString();
                        swaptionDTO.NotionalAmount = Convert.ToDouble(reader["notional_amount"]);
                        swaptionDTO.PricingModel = reader["pricing_model"].ToString();
                        swaptionDTO.PaymentFrequencyMonths = Convert.ToInt32(reader["payment_frequency_months"]);
                        swaptionDTO.DayCountConvention = reader["day_count_convention"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"GetEuropeanSwaptionById-Error : {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return swaptionDTO;
        }

        public int InsertSwaption(ISwaptionDTO swaption)
        {
            var swaptionId = 0;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("usp_InsertEuropeanSwaption", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@product_type", SqlDbType.NVarChar).Value = swaption.ProductType;
                    sqlCommand.Parameters.AddWithValue("@option_type", SqlDbType.NVarChar).Value = swaption.OptionType;
                    sqlCommand.Parameters.AddWithValue("@settlement_type", SqlDbType.NVarChar).Value = swaption.SettlementType;
                    sqlCommand.Parameters.AddWithValue("@option_effective_date", SqlDbType.Date).Value = swaption.OptionEffectiveDate;
                    sqlCommand.Parameters.AddWithValue("@option_expiration_date", SqlDbType.Date).Value = swaption.OptionExpirationDate;
                    sqlCommand.Parameters.AddWithValue("@option_valuation_date", SqlDbType.Date).Value = swaption.OptionValuationDate;
                    sqlCommand.Parameters.AddWithValue("@swap_start_date", SqlDbType.Date).Value = swaption.SwapStartDate;
                    sqlCommand.Parameters.AddWithValue("@swap_end_date", SqlDbType.Date).Value = swaption.SwapEndDate;
                    sqlCommand.Parameters.AddWithValue("@option_price", SqlDbType.Float).Value = swaption.OptionPrice;
                    sqlCommand.Parameters.AddWithValue("@strike_rate", SqlDbType.Float).Value = swaption.StrikeRate;
                    sqlCommand.Parameters.AddWithValue("@float_rate_reference", SqlDbType.NVarChar).Value = swaption.FloatRateReference;
                    sqlCommand.Parameters.AddWithValue("@currency", SqlDbType.NVarChar).Value = swaption.Currency;
                    sqlCommand.Parameters.AddWithValue("@notional_amount", SqlDbType.Float).Value = swaption.NotionalAmount;
                    sqlCommand.Parameters.AddWithValue("@pricing_model", SqlDbType.NVarChar).Value = swaption.PricingModel;
                    sqlCommand.Parameters.AddWithValue("@payment_frequency_months", SqlDbType.Int).Value = swaption.PaymentFrequencyMonths;
                    sqlCommand.Parameters.AddWithValue("@day_count_convention", SqlDbType.NVarChar).Value = swaption.DayCountConvention;

                    var swaptionIdParam = sqlCommand.Parameters.Add("@swaptionId", SqlDbType.Int);
                    swaptionIdParam.Direction = ParameterDirection.Output;
                    swaptionIdParam.Value = swaptionId;
                    try
                    {

                        sqlCommand.ExecuteNonQuery();
                        swaptionId = (int)swaptionIdParam.Value;
                    }
                    catch (Exception ex) 
                    {
                        throw new Exception($"InsertEuropeanSwaption-Error : {ex.Message}");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
                return swaptionId;
            }
        }

    }
}
