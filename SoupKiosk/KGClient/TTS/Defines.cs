using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public enum LoadResults : short
    {
        [Description("성공")]
        VT_LOADTTS_SUCCESS = 0,
        [Description("[1] Multiple DB를 사용할 때 다른 db_path로 동일 음색의 DB Load를 시도한 경우")]
        VT_LOADTTS_ERROR_CONFLICT_DBPATH = 1,
        [Description("[2] 채널 메모리 확보에 실패한 경우")]
        VT_LOADTTS_ERROR_TTS_STRUCTURE = 2,
        [Description("[3] 형태소 분석에 관련된 DB Load에 실패한 경우")]
        VT_LOADTTS_ERROR_TAGGER = 3,
        [Description("[4] 끊어 읽기(Break Index)에 관련된 DB Load에 실패한 경우")]
        VT_LOADTTS_ERROR_BREAK_INDEX = 4,
        [Description("[5] 텍스트 전처리에 관련된 DB Load에 실패한 경우")]
        VT_LOADTTS_ERROR_TPP_DICT = 5,
        [Description("[6] 음향학적 모델에 관련된 DB Load에 실패한 경우")]
        VT_LOADTTS_ERROR_TABLE = 6,
        [Description("[7] 단위 선정에 관련된 DB Load에 실패한 경우")]
        VT_LOADTTS_ERROR_UNIT_INDEX = 7,
        [Description("[8] 운율 모델에 관련된 DB Load에 실패한 경우")]
        VT_LOADTTS_ERROR_PROSODY_DB = 8,
        [Description("[9] 음성 DB Load에 실패한 경우")]
        VT_LOADTTS_ERROR_PCM_DB = 9,
        [Description("[10] 피치 위치 정보에 관련된 DB Load에 실패한 경우")]
        VT_LOADTTS_ERROR_PM_DB = 10,
        [Description("[11] 기타의 이유")]
        VT_LOADTTS_ERROR_UNKNOWN = 11,
        [Description("정의되지 않은 오류")]
        UNDEFINED_ERROR = 98,
        [Description()]
        EXCEPTION = 99
    }

    public enum PlayResults : short
    {
        [Description("성공")]
        VT_PLAY_API_SUCCESS = 1,
        [Description("[-1] 채널 메모리 확보에 실패한 경우")]
        VT_PLAY_API_ERROR_CREATE_THREAD = -1,
        [Description("[-2] 텍스트 문자열이 NULL pointer인 경우")]
        VT_PLAY_API_ERROR_NULL_TEXT = -2,
        [Description("[-3] 텍스트 문자열의 길이가 0인 경우")]
        VT_PLAY_API_ERROR_EMPTY_TEXT = -3,
        [Description("[-4] 해당 음색의 합성 DB가 Load 되어 있지 않은 경우")]
        VT_PLAY_API_ERROR_DB_NOT_LOADED = -4,
        [Description("[-5] 사운드 카드의 설정에 실패한 경우")]
        VT_PLAY_API_ERROR_INITPLAY = -5,
        [Description("[-6] 기타의 이유")]
        VT_PLAY_API_ERROR_UNKNOWN = -6,
        [Description("정의되지 않은 오류")]
        UNDEFINED_ERROR = 98,
        [Description("예외오류(Exception)")]
        EXCEPTION = 99
    }
}
