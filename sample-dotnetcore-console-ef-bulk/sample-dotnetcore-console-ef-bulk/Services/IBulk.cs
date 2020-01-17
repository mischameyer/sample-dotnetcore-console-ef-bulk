using System;
using System.Collections.Generic;
using System.Text;

namespace sample_dotnetcore_console_ef_bulk.Services
{
    public interface IBulk
    {
        void GetData();

        void InsertBulkData(int count);

        void UpdateBulkData();
    }
}
