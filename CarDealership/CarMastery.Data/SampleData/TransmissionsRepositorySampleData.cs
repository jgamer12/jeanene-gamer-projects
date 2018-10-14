using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class TransmissionsRepositorySampleData : ITransmissionsRepository
    {
        public static List<Transmissions> _Transmissions = new List<Transmissions>
        {
            new Transmissions
                {TransmissionId=1, TransmissionDescription = "Automatic"},
            new Transmissions
                {TransmissionId=2, TransmissionDescription = "Manual"}
        };
        public List<Transmissions> GetAllTransmissions()
        {
            return _Transmissions;
        }
    }
}
