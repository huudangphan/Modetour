using System.Data;
using System.Data.SqlClient;

namespace ModeTour.Commons.Helper
{
    public class DBHelper
    {
        private static string _key = "ModeDBSingleton";
        #region "Variable"
        /// <summary>
        /// 데이터베이스 연결 객체
        /// </summary>
        private SqlConnection m_objConnection;
        /// <summary>
        /// 트랜젝션 객체
        /// </summary>
        private SqlTransaction m_objTransaction;
        /// <summary>
        /// 트랜젝션 사용여부
        /// </summary>
        /// 
        private SqlDataAdapter m_objDataAdapter;


        private bool m_bTrans = false;
        #endregion


        #region "Property"
        /// <summary>
        /// 데이터베이스 연결 객체 속성 Property
        /// </summary>
        public SqlConnection Connection
        {
            set { ObjConnection = value; }
            get { return ObjConnection; }
        }

        /// <summary>
        /// 데이터베이스 연결 문자열 Property
        /// </summary>
        public string ConnectionString
        {
            //set { m_objConnection = new SqlConnection(GlobalData.connectionStrModeWeb3); }
            get; set;
        }
        public SqlConnection ObjConnection { get => m_objConnection; set => m_objConnection = value; }
        #endregion


        #region "Method"
        /// <summary>
        /// 생성자
        /// </summary>
        public DBHelper()
        {

        }

        /// <summary>
        /// 데이터베이스 연결 문자열 생성자
        /// </summary>
        /// <param name="ConnectionStr">데이터베이스 연결 문자열</param>
        /// <param name="OpenSw">데이터베이스 Open 여부</param>
        public DBHelper(string ConnectionStr, bool OpenSw)
        {
            ConnectionString = ConnectionStr;
            ObjConnection = new SqlConnection(ConnectionString);
            if (OpenSw) Open();
        }

        /// <summary>
        /// 데이터베이스 연결
        /// </summary>
        public void Open()
        {
            try
            {
                if (ObjConnection.State != ConnectionState.Open) ObjConnection.Open();
            }
            catch (Exception ex)
            {
                //throw new CommonException("Common", "DBController", "Open()", ex.Message);
            }
        }

        /// <summary>
        /// 데이터베이스 연결 종료
        /// </summary>
        public void Close()
        {
            try
            {
                if (ObjConnection.State != ConnectionState.Closed) ObjConnection.Close();
                ObjConnection.Dispose();
            }
            catch (Exception ex)
            {
                //throw new CommonException("Common", "DBController", "Close()", ex.Message);
            }
        }

        /// <summary>
        /// 트랜젝션 시작
        /// </summary>
        public void BeginTrans()
        {
            BeginTrans(IsolationLevel.ReadCommitted);
        }
        /// <summary>
        /// 트랜젝션 시작
        /// </summary>
        public void BeginTrans(IsolationLevel iso)
        {
            try
            {
                if (ObjConnection.State == ConnectionState.Open) m_objTransaction = ObjConnection.BeginTransaction(iso);
                m_bTrans = true;
            }
            catch (Exception ex)
            {
                //throw new CommonException("Common", "DBController", "BeginTrans()", ex.Message);
            }
        }

        /// <summary>
        /// 트랜젝션 커밋
        /// </summary>
        public void Commit()
        {
            try
            {
                if (m_bTrans) m_objTransaction.Commit();
                m_bTrans = false;
                m_objTransaction.Dispose();
            }
            catch (Exception ex)
            {
                //throw new CommonException("Common", "DBController", "Commit()", ex.Message);
            }
        }

        /// <summary>
        /// 트랜젝션 롤백
        /// </summary>
        public void Rollback()
        {
            try
            {
                if (m_bTrans) m_objTransaction.Rollback();
                m_bTrans = false;
                m_objTransaction.Dispose();
            }
            catch (Exception ex)
            {
                //throw new CommonException("Common", "DBController", "Rollback()", ex.Message);
            }
        }

        /// <summary>
        /// 프로시저 명
        /// </summary>
        public void SetProcedureName(string procename)
        {
            m_objDataAdapter = new SqlDataAdapter(procename, ObjConnection);
            m_objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

        }
        /// <summary>
        /// 파라미터 설정
        /// </summary>
        /// <param name="tValue">파라미터값</param>
        /// <param name="sName">파라미터명</param>
        /// <param name="nSqlDbType">파라미터타입</param>
        /// <param name="nSize">파라미터사이즈</param>
        /// <param name="BInput">input/output/inout/return</param>
        public void SetParameter(object tValue, string sName, SqlDbType nSqlDbType, int nSize, string BInput)
        {
            SqlParameter tParameter = new SqlParameter(sName, nSqlDbType, nSize);

            if (BInput.ToLower() == "output")
            {
                tParameter.Direction = ParameterDirection.Output;
            }
            else if (BInput.ToLower() == "return")
            {
                tParameter.Direction = ParameterDirection.ReturnValue;
            }
            else if (BInput.ToLower() == "inout")
            {
                tParameter.Direction = ParameterDirection.InputOutput;
            }
            else
            {
                tParameter.Value = tValue;
            }

            AddParameters(tParameter);
        }
        /// <summary>
        /// 파라미터 설정
        /// </summary>
        /// <param name="param">Stored Procedure 파라미터 배열</param>
        public void SetParameter(Dictionary<string, object> param)
        {
            Dictionary<string, object>.Enumerator ie = param.GetEnumerator();
            while (ie.MoveNext())
            {
                AddParameters(new SqlParameter(ie.Current.Key, ie.Current.Value));
            }
        }
        /// <summary>
        /// 파라미터 설정
        /// </summary>
        /// <param name="name">파라미터명</param>
        /// <param name="value">파라미터값</param>
        public void SetParameter(string name, object value)
        {
            AddParameters(new SqlParameter(name, value));
        }
        /// <summary>
        /// 파라미터 설정
        /// </summary>
        /// <param name="name">파라미터명</param>
        /// <param name="value">파라미터값</param>
        /// <param name="direction">파라미터타입</param>
        public void SetParameter(string name, object value, ParameterDirection direction)
        {
            SqlParameter p = new SqlParameter(name, value);
            p.Direction = direction;
            AddParameters(p);
        }

        /// <summary>
        /// 파라미터 설정
        /// </summary>
        /// <param name="name">파라미터명</param>
        /// <param name="value">파라미터값</param>
        /// <param name="size">파라미터사이즈</param>
        /// <param name="direction">파라미터타입</param>
        public void SetParameter(string name, object value, int size, ParameterDirection direction)
        {
            SqlParameter p = new SqlParameter(name, value);
            p.Size = size;
            p.Direction = direction;
            AddParameters(p);
        }

        /// <summary>
        /// 파라미터 초기화
        /// </summary>
        public void ClearParameter()
        {
            if (m_objDataAdapter.SelectCommand != null && m_objDataAdapter.SelectCommand.Parameters.Count > 0)
            {
                m_objDataAdapter.SelectCommand.Parameters.Clear();
            }
        }

        /// <summary>
        /// 파라미터 추가
        /// </summary>
        public void AddParameters(SqlParameter tParameter)
        {
            m_objDataAdapter.SelectCommand.Parameters.Add(tParameter);
        }

        /// <summary>
        /// 파라미터값 가져오기
        /// </summary>
        public object GetParameter(string sName)
        {
            return m_objDataAdapter.SelectCommand.Parameters[sName].Value;
        }

        /// <summary>
        /// DataTable Row 존재유무
        /// BOF : 처음과 끝이 같은지 여부
        /// </summary>
        /// <returns>데이터 로우 있음: false / 데이터 로우 없음 : true</returns>
        public static bool IsBOF(DataTable sTablename)
        {
            int RowsCount = 0;
            bool sResult = true;

            RowsCount = sTablename.Rows.Count;
            if (RowsCount > 0)
            {
                sResult = false;
            }
            else
            {
                sResult = true;
            }
            return sResult;
        }

        public int Execute()
        {
            if (m_objTransaction != null)
            {
                m_objDataAdapter.SelectCommand.Transaction = m_objTransaction;
            }

            return m_objDataAdapter.SelectCommand.ExecuteNonQuery();
        }
        public int Execute(out DataSet data)
        {
            DataSet objDs = null;

            if (m_objTransaction != null)
            {
                m_objDataAdapter.SelectCommand.Transaction = m_objTransaction;
            }
            objDs = new DataSet();
            int result = m_objDataAdapter.Fill(objDs);
            data = objDs;
            return result;
        }
        /// <summary>
        /// Stored Procedure 수행1 (Only DataSet)
        /// </summary>
        /// <param name="procname">Stored Procedure 명</param>
        /// <param name="param">Stored Procedure 파라미터 배열</param>
        /// <param name="alias">소스 테이블 명</param>
        /// <returns>데이타셋</returns>
        public DataSet Execute(string procname, Dictionary<string, object> param, string alias)
        {
            int nCnt = 0;
            object[] objOb = null;
            SqlParameter[] p = new SqlParameter[param.Count];

            Dictionary<string, object>.Enumerator ie = param.GetEnumerator();
            while (ie.MoveNext())
            {
                p[nCnt] = new SqlParameter();
                p[nCnt].ParameterName = ie.Current.Key;
                p[nCnt].Value = ie.Current.Value;

                nCnt++;
            }

            return Execute(procname, p, null, null, ref objOb);
        }
        /// <summary>
        /// Stored Procedure 수행1 (Only DataSet)
        /// </summary>
        /// <param name="procname">Stored Procedure 명</param>
        /// <param name="param">Stored Procedure 파라미터 배열</param>
        /// <param name="alias">소스 테이블 명</param>
        /// <returns>데이타셋</returns>
        public DataSet Execute(string procname, SqlParameter[] param, string alias)
        {
            object[] objOb = null;
            return Execute(procname, param, null, null, ref objOb);
        }
        /// <summary>
        /// Stored Procedure 수행1 (DataSet + Output Value)
        /// </summary>
        /// <param name="procname">Stored Procedure 명</param>
        /// <param name="param">Stored Procedure 파라미터 배열</param>
        /// <param name="alias">소스 테이블 명</param>
        /// <returns>데이타셋</returns>
        public DataSet Execute(string procname, SqlParameter[] param, string alias, string outname, ref object outvalue)
        {
            string[] strOutParams = new string[] { outname };
            object[] objOb = null;
            DataSet objDs = null;

            objDs = Execute(procname, param, null, strOutParams, ref objOb);
            outvalue = objOb[0];

            return objDs;
        }
        /// <summary>
        /// Stored Procedure 수행1  (DataSet + Output Array Value)
        /// </summary>
        /// <param name="procname">Stored Procedure 명</param>
        /// <param name="param">Stored Procedure 파라미터 배열</param>
        /// <param name="alias">소스 테이블 명</param>
        /// <param name="outname">Output 파라미터명 배열</param>
        /// <param name="outvalue">Output 결과Object 배열</param>
        /// <returns>데이타셋</returns>
        public DataSet Execute(string procname, SqlParameter[] param, string alias, string[] outname, ref object[] outvalue)
        {
            SqlCommand objComm = null;
            //SqlDataAdapter objAdapter = null;
            DataSet objDs = null;

            try
            {

                objComm = new SqlCommand();
                objComm.Connection = ObjConnection;
                objComm.CommandType = CommandType.StoredProcedure;
                objComm.CommandText = procname;


                if (param != null) foreach (SqlParameter p in param) objComm.Parameters.Add(p);

                m_objDataAdapter = new SqlDataAdapter();
                m_objDataAdapter.SelectCommand = objComm;


                objDs = new DataSet();
                if (alias == null) m_objDataAdapter.Fill(objDs);
                else m_objDataAdapter.Fill(objDs, alias);

                if (outname != null)
                {
                    outvalue = new object[outname.Length];
                    for (int i = 0; i < outname.Length; i++)
                        outvalue[i] = m_objDataAdapter.SelectCommand.Parameters[outname[i]].Value;
                }

            }
            catch (Exception ex)
            {
                objDs = null;
                //throw new CommonException("Common", "DBController", "Execute()", ex.Message);
            }
            finally
            {
                if (m_objDataAdapter != null) m_objDataAdapter.Dispose();
                objComm.Dispose();
            }

            return objDs;
        }
        /// <summary>
        /// Stored Procedure 실행2
        /// </summary>
        /// <param name="procname">프로시저 명</param>
        /// <param name="param">파라미터 배열명</param>
        /// <returns>실행후 object형을 리턴한다.</returns>
        public object ExecuteScalar(string procname, Dictionary<string, object> param)
        {
            SqlCommand objComm = null;
            //SqlDataAdapter objAdapter = null;
            object objOb = null;

            try
            {
                objComm = new SqlCommand();
                objComm.Connection = ObjConnection;
                if (m_bTrans) objComm.Transaction = m_objTransaction;
                objComm.CommandType = CommandType.StoredProcedure;
                objComm.CommandText = procname;

                Dictionary<string, object>.Enumerator ie = param.GetEnumerator();
                while (ie.MoveNext())
                {
                    SqlParameter p = new SqlParameter(ie.Current.Key, ie.Current.Value);
                    objComm.Parameters.Add(p);
                }

                objOb = objComm.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                objOb = null;
                //throw new CommonException("Common", "DBController", "ExecuteScalar", ex.Message);
            }
            finally
            {
                if (m_objDataAdapter != null) m_objDataAdapter.Dispose();
                objComm.Dispose();
            }

            return objOb;
        }
        /// <summary>
        /// Stored Procedure 실행2
        /// </summary>
        /// <param name="procname">프로시저 명</param>
        /// <param name="param">파라미터 배열명</param>
        /// <param name="outname">Output 파라미터명</param>
        /// <returns>실행후 object형을 리턴한다.</returns>
        public object ExecuteScalar(string procname, SqlParameter[] param, string outname)
        {
            SqlCommand objComm = null;
            //SqlDataAdapter objAdapter = null;
            object objOb = null;

            try
            {
                objComm = new SqlCommand();
                objComm.Connection = ObjConnection;
                if (m_bTrans) objComm.Transaction = m_objTransaction;
                objComm.CommandType = CommandType.StoredProcedure;
                objComm.CommandText = procname;



                if (param != null) foreach (SqlParameter p in param) objComm.Parameters.Add(p);

                if (outname != null && outname != "")
                {
                    objComm.ExecuteNonQuery();
                    objOb = objComm.Parameters[outname].Value;
                }
                else
                    objOb = objComm.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                objOb = null;
                //throw new CommonException("Common", "DBController", "ExecuteScalar", ex.Message);
            }
            finally
            {
                if (m_objDataAdapter != null) m_objDataAdapter.Dispose();
                objComm.Dispose();
            }

            return objOb;
        }
        /// <summary>
        /// Stored Procedure 실행2
        /// </summary>
        /// <param name="procname">프로시저 명</param>
        /// <param name="param">파라미터 배열명</param>
        /// <param name="outname">Output 파라미터명</param>
        /// <returns>실행후 object배열형을 리턴한다.</returns>
        public object[] ExecuteScalar(string procname, SqlParameter[] param, string[] outname)
        {
            SqlCommand objComm = null;
            //SqlDataAdapter objAdapter = null;
            object[] objOb = null;

            try
            {
                objComm = new SqlCommand();
                objComm.Connection = ObjConnection;
                if (m_bTrans) objComm.Transaction = m_objTransaction;
                objComm.CommandType = CommandType.StoredProcedure;
                objComm.CommandText = procname;
                if (param != null) foreach (SqlParameter p in param) objComm.Parameters.Add(p);

                if (outname != null)
                {
                    objComm.ExecuteNonQuery();
                    objOb = new object[outname.Length];
                    for (int i = 0; i < outname.Length; i++)
                        objOb[i] = objComm.Parameters[outname[i]].Value;
                }
            }
            catch (System.Exception ex)
            {
                objOb = null;
                //throw new CommonException("Common", "DBController", "ExecuteScalar", ex.ToString());
            }
            finally
            {
                if (m_objDataAdapter != null) m_objDataAdapter.Dispose();
                objComm.Dispose();
            }

            return objOb;
        }

        /// <summary>
        /// Stored Procedure 실행3
        /// </summary>
        /// <param name="procname">프로시저 명</param>
        /// <param name="param">파라미터 배열명</param>
        /// <returns>실행후 int형을 리턴한다.</returns>
        public int ExecuteNonQuery(string procname, Dictionary<string, object> param)
        {
            int nVal = Convert.ToInt32(ExecuteScalar(procname, param));
            return nVal;
        }
        /// <summary>
        /// Stored Procedure 실행3
        /// </summary>
        /// <param name="procname">프로시저 명</param>
        /// <param name="param">파라미터 배열명</param>
        /// <returns>실행후 int형을 리턴한다.</returns>
        public int ExecuteNonQuery(string procname, SqlParameter[] param)
        {
            int nVal = Convert.ToInt32(ExecuteScalar(procname, param, ""));
            return nVal;
        }
        #endregion
    }
}
