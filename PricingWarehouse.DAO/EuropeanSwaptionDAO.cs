using PricingWarehouse.DTO;
using System.Data;
using System.Data.SqlClient;

namespace PricingWarehouse.DAO
{
    public class EuropeanSwaptionDAO:IProducDAO<ISwaptionDTO>
    {
        private readonly string _connectionString;
        public EuropeanSwaptionDAO(string connectionString)
            {
            _connectionString = connectionString;
            }

        public ISwaptionDTO GetProductById(int swaptionId)
        {
            var europeanSwaptionDTO = new EuropeanSwaptionDTO();
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
                        europeanSwaptionDTO.OptionType = reader["option_type"].ToString();
                        europeanSwaptionDTO.SettlementType = reader["settlement_type"].ToString();
                        europeanSwaptionDTO.OptionEffectiveDate = Convert.ToDateTime(reader["option_effective_date"]);
                        europeanSwaptionDTO.OptionExpirationDate = Convert.ToDateTime(reader["option_expiration_date"]);
                        europeanSwaptionDTO.OptionValuationDate = Convert.ToDateTime(reader["option_valuation_date"]);
                        europeanSwaptionDTO.SwapStartDate = Convert.ToDateTime(reader["swap_start_date"]);
                        europeanSwaptionDTO.SwapEndDate = Convert.ToDateTime(reader["swap_end_date"]);
                        europeanSwaptionDTO.Price = Convert.ToDouble(reader["price"]);
                        europeanSwaptionDTO.StrikeRate = Convert.ToDouble(reader["strike_rate"]);
                        europeanSwaptionDTO.FloatingRateReference = reader["floating_rate_reference"].ToString();
                        europeanSwaptionDTO.FloatingRateSpread = Convert.ToDouble(reader["floating_rate_reference"]);
                        europeanSwaptionDTO.Currency = reader["currency"].ToString();
                        europeanSwaptionDTO.NotionalAmount = Convert.ToDouble(reader["notional_amount"]);
                        europeanSwaptionDTO.PricingModel = reader["pricing_model"].ToString();
                        europeanSwaptionDTO.PaymentFrequencyMonths = Convert.ToInt32(reader["payment_frequency_months"]);
                        europeanSwaptionDTO.DayCountConvention = reader["day_count_convention"].ToString();

                        europeanSwaptionDTO.Delta = Convert.ToDouble(reader["delta"]);
                        europeanSwaptionDTO.Gamma = Convert.ToDouble(reader["gamma"]);
                        europeanSwaptionDTO.Vega = Convert.ToDouble(reader["vega"]);


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
            return europeanSwaptionDTO;
        }

        public int InsertProduct(ISwaptionDTO swaption)
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
                    sqlCommand.Parameters.AddWithValue("@price", SqlDbType.Float).Value = swaption.Price;
                    sqlCommand.Parameters.AddWithValue("@strike_rate", SqlDbType.Float).Value = swaption.StrikeRate;
                    sqlCommand.Parameters.AddWithValue("@floating_rate_reference", SqlDbType.NVarChar).Value = swaption.FloatingRateReference;
                    sqlCommand.Parameters.AddWithValue("@floating_rate_spread", SqlDbType.Float).Value = swaption.FloatingRateSpread;
                    sqlCommand.Parameters.AddWithValue("@currency", SqlDbType.NVarChar).Value = swaption.Currency;
                    sqlCommand.Parameters.AddWithValue("@notional_amount", SqlDbType.Float).Value = swaption.NotionalAmount;
                    sqlCommand.Parameters.AddWithValue("@pricing_model", SqlDbType.NVarChar).Value = swaption.PricingModel;
                    sqlCommand.Parameters.AddWithValue("@payment_frequency_months", SqlDbType.Int).Value = swaption.PaymentFrequencyMonths;
                    sqlCommand.Parameters.AddWithValue("@day_count_convention", SqlDbType.NVarChar).Value = swaption.DayCountConvention;

                    sqlCommand.Parameters.AddWithValue("@delta", SqlDbType.Float).Value = swaption.Delta;
                    sqlCommand.Parameters.AddWithValue("@gamma", SqlDbType.Float).Value = swaption.Gamma;
                    sqlCommand.Parameters.AddWithValue("@vega", SqlDbType.Float).Value = swaption.Vega;


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
