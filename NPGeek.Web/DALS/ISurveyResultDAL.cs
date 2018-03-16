using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPGeek.Web.DALS
{
    public interface ISurveyResultDAL
    {
        List<string> GetParkCodeByVote();
    }
}
