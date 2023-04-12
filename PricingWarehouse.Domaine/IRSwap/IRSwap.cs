using PricingWarehouse.Domaine.Swaptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingWarehouse.Domain.IRSwap
{
    public interface IIRSwap
    {
        FixedRate FixedRate { get; }
        FloatingRateReference FloatingRateReference { get; }
        FloatingRateSpread FloatingRateSpread { get; }
        PaymentFrequencyMonths PaymentFrequencyMonths { get; }
        SwapValue SwapValue { get; }
        Currency Currency { get; }
        DayCountConvention DayCountConvention { get; }
        StartDate StartDate { get; }
        EndDate EndDate { get; }
        Notional Notional { get; }
        ValuationDate ValuationDate { get; }
        int SwapId { get; }
        void SetSwapValue(int swapValue);
        void SetSwapId(int swapId);
    }
    public class IRSwap:IIRSwap
    {
        public FixedRate FixedRate { get; private set; }
        public FloatingRateReference FloatingRateReference { get; private set; }
        public FloatingRateSpread FloatingRateSpread { get; private set; }
        public PaymentFrequencyMonths PaymentFrequencyMonths { get; private set; }
        public SwapValue SwapValue { get; private set; }
        public Currency Currency { get; private set; }
        public DayCountConvention DayCountConvention { get; private set; }
        public StartDate StartDate { get; private set; }
        public EndDate EndDate { get; private set; }
        public Notional Notional { get; private set; }
        public ValuationDate ValuationDate { get; private set; }
        public int SwapId { get; private set; } 
        public IRSwap(FixedRate fixedRate, FloatingRateReference floatingRateReference, FloatingRateSpread floatingRateSpread,
            PaymentFrequencyMonths paymentFrequencyMonths, SwapValue swapValue, Currency currency, DayCountConvention dayCountConvention,
            StartDate startDate, EndDate endDate, Notional notional, ValuationDate valuationDate)
        {
            FixedRate = fixedRate;
            FloatingRateReference = floatingRateReference;
            FloatingRateSpread = floatingRateSpread;
            PaymentFrequencyMonths = paymentFrequencyMonths;
            SwapValue = swapValue;
            Currency = currency;
            DayCountConvention = dayCountConvention;
            StartDate = startDate;
            EndDate = endDate;
            Notional = notional;
            ValuationDate = valuationDate;
        }

        public void SetSwapValue(int swapValue)
        {
            if (swapValue == null)
            {
                SwapValue = new SwapValue(swapValue);
            }
            else
            {
                SwapValue.Value = swapValue;
            }
        }
        public void SetSwapId(int swapId)
        {
            SwapId = swapId;
        }
    }
}
