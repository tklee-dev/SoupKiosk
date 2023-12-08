using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public enum PrintingResults
    {
        /// <summary>
        /// 완료
        /// </summary>
        Success,

        /// <summary>
        /// 회수기 안의 문서를 배출해야한다.
        /// </summary>
        LastCopyOrNeedDipense,

        /// <summary>
        /// 문서가 회수기에 적재 상태이다.
        /// </summary>
        StackedDocument,

        /// <summary>
        /// 고객이 문서를 가져가지 않았다.
        /// </summary>
        CollectedDocument,

        /// <summary>
        /// 인증기 장애
        /// </summary>
        StaplerError,

        /// <summary>
        /// 회수기 장애
        /// </summary>
        PbMachineError,
    }
}
