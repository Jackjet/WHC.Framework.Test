using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using TMIS.Entity;
using TMIS.IDAL;
using WHC.Pager.Entity;

namespace TMIS.BLL
{
	public class Customer : BaseBLL<CustomerInfo>
    {
        public Customer()
            : base()
        {
        }

        /// <summary>
        /// ɾ���û������ϺͲ�����Ϣ
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool Delete(string key)
        {
            baseDal.DeleteByKey(key);

            //ICustomerTrade tradeDAL = new DALDatabase.CustomerTrade();
            //string condition = string.Format("Customer_ID ='{0}'", key);
            //tradeDAL.DeleteByCondition(condition);

            return true;
        }

        /// <summary>
        /// ��ȡ���еĿͻ����
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllCustomerNumber()
        {
            ICustomer customerDAL = baseDal as ICustomer;
            return customerDAL.GetAllCustomerNumber();
        }

        /// <summary>
        /// ���ݿͻ���Ż�ȡ�ͻ���Ϣ
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public CustomerInfo GetByCustomerNumber(string number)
        {
            ICustomer customerDAL = baseDal as ICustomer;
            return customerDAL.GetByCustomerNumber(number);
        }

        /// <summary>
        /// ��ȡû�ж����Ŀͻ��б�
        /// </summary>
        /// <param name="pagerInfo">���pagerInfoΪ�գ������ط�ҳ���ݣ�����ȫ������</param>
        /// <returns></returns>
        public List<CustomerInfo> GetNoOrderCustomers(PagerInfo pagerInfo)
        {
            List<CustomerInfo> customerList = new List<CustomerInfo>();

            //IOrder orderDAL = new DALDatabase.Order();
            //List<string> customerNumberList = orderDAL.GetCustomerNumbers();

            //string numberString = string.Empty;
            //foreach (string number in customerNumberList)
            //{
            //    numberString += string.Format("'{0}',", number);
            //}

            //if (!string.IsNullOrEmpty(numberString))
            //{
            //    string condition = string.Format("Number not in({0})", numberString.Trim(','));
            //    ICustomer customerDAL = baseDal as ICustomer;

            //    if (pagerInfo != null)
            //    {
            //        customerList = customerDAL.Find(condition, pagerInfo);
            //    }
            //    else
            //    {
            //        customerList = customerDAL.Find(condition);
            //    }
            //}

            return customerList;
        }

        /// <summary>
        /// ���ݷֵ�������ɿͻ����
        /// </summary>
        /// <param name="shopID">�ֵ�ID</param>
        /// <returns></returns>
        public string GenerateCustomerNumber(string shopID)
        {
            string shopCode = string.Empty;
            //string condition = string.Format("ID ='{0}'", shopID);
            //IShop shop = new DALDatabase.Shop();
            //List<ShopInfo> shopList = shop.Find(condition);
            //if (shopList.Count > 0)
            //{
            //    shopCode = shopList[0].ShopCode;
            //}

            //condition = string.Format("Shop_ID ='{0}'", shopID);
            //ICustomer dal = baseDal as ICustomer;
            int count = 1;// dal.GetRecordCount(condition) + 1;
                        
            string number = string.Format("{0}{1}", shopCode, count);
            while (true)
            {
                if (CheckCustomerNumberExist(number))
                {
                    number = string.Format("{0}{1}", shopCode, count++);
                }
                else
                {
                    break;
                }
            }

            return number;
        }

        private bool CheckCustomerNumberExist(string customerNumber)
        {
            return base.IsExistKey("Number", customerNumber);
        }
    }
}
