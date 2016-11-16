﻿using System;
using System.Collections.Generic;

namespace Weixin.Next.Payment
{
    // ReSharper disable InconsistentNaming
    /// <summary>
    /// 银行卡类型
    /// </summary>
    public enum BankCardType
    {
        /// <summary>
        /// 借记卡
        /// </summary>
        DEBIT,
        /// <summary>
        /// 信用卡
        /// </summary>
        CREDIT
    }

    /// <summary>
    /// 银行
    /// </summary>
    public class Bank
    {
        private readonly string _id;
        private readonly string _name;

        public Bank(string id, string name)
        {
            _id = id;
            _name = name;
        }

        public Bank(string id)
        {
            _id = id;
            _name = Find(id)?.Name;
        }

        public string Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        #region All

        private static readonly Dictionary<string, Bank> _all = new Dictionary<string, Bank>
        {
            {"ICBC", new Bank("ICBC", "工商银行")},
            {"ABC", new Bank("ABC", "农业银行")},
            {"PSBC", new Bank("PSBC", "邮政储蓄银行")},
            {"CCB", new Bank("CCB", "建设银行")},
            {"CMB", new Bank("CMB", "招商银行")},
            {"BOC", new Bank("BOC", "中国银行")},
            {"COMM", new Bank("COMM", "交通银行")},
            {"SPDB", new Bank("SPDB", "浦发银行")},
            {"GDB", new Bank("GDB", "广发银行")},
            {"CMBC", new Bank("CMBC", "民生银行")},
            {"PAB", new Bank("PAB", "平安银行")},
            {"CEB", new Bank("CEB", "光大银行")},
            {"CIB", new Bank("CIB", "兴业银行")},
            {"CITIC", new Bank("CITIC", "中信银行")},
            {"BOSH", new Bank("BOSH", "上海银行")},
            {"CRB", new Bank("CRB", "华润银行")},
            {"HZB", new Bank("HZB", "杭州银行")},
            {"BSB", new Bank("BSB", "包商银行")},
            {"CQB", new Bank("CQB", "重庆银行")},
            {"SDEB", new Bank("SDEB", "顺德农商行")},
            {"SZRCB", new Bank("SZRCB", "深圳农商银行")},
            {"HRBB", new Bank("HRBB", "哈尔滨银行")},
            {"BOCD", new Bank("BOCD", "成都银行")},
            {"GDNYB", new Bank("GDNYB", "南粤银行")},
            {"GZCB", new Bank("GZCB", "广州银行")},
            {"JSB", new Bank("JSB", "江苏银行")},
            {"NBCB", new Bank("NBCB", "宁波银行")},
            {"NJCB", new Bank("NJCB", "南京银行")},
            {"JZB", new Bank("JZB", "晋中银行")},
            {"KRCB", new Bank("KRCB", "昆山农商")},
            {"LJB", new Bank("LJB", "龙江银行")},
            {"LNNX", new Bank("LNNX", "辽宁农信")},
            {"LZB", new Bank("LZB", "兰州银行")},
            {"WRCB", new Bank("WRCB", "无锡农商")},
            {"ZYB", new Bank("ZYB", "中原银行")},
            {"ZJRCUB", new Bank("ZJRCUB", "浙江农信")},
            {"WZB", new Bank("WZB", "温州银行")},
            {"XAB", new Bank("XAB", "西安银行")},
            {"JXNXB", new Bank("JXNXB", "江西农信")},
            {"NCB", new Bank("NCB", "宁波通商银行")},
            {"NYCCB", new Bank("NYCCB", "南阳村镇银行")},
            {"NMGNX", new Bank("NMGNX", "内蒙古农信")},
            {"SXXH", new Bank("SXXH", "陕西信合")},
            {"SRCB", new Bank("SRCB", "上海农商银行")},
            {"SJB", new Bank("SJB", "盛京银行")},
            {"SDRCU", new Bank("SDRCU", "山东农信")},
            {"SCNX", new Bank("SCNX", "四川农信")},
            {"QLB", new Bank("QLB", "齐鲁银行")},
            {"QDCCB", new Bank("QDCCB", "青岛银行")},
            {"PZHCCB", new Bank("PZHCCB", "攀枝花银行")},
            {"ZJTLCB", new Bank("ZJTLCB", "浙江泰隆银行")},
            {"TJBHB", new Bank("TJBHB", "天津滨海农商行")},
            {"WEB", new Bank("WEB", "微众银行")},
            {"YNRCCB", new Bank("YNRCCB", "云南农信")},
            {"WFB", new Bank("WFB", "潍坊银行")},
            {"WHRC", new Bank("WHRC", "武汉农商行")},
            {"ORDOSB", new Bank("ORDOSB", "鄂尔多斯银行")},
            {"XJRCCB", new Bank("XJRCCB", "新疆农信银行")},
            {"CSRCB", new Bank("CSRCB", "常熟农商银行")},
            {"JSNX", new Bank("JSNX", "江苏农商行")},
            {"GRCB", new Bank("GRCB", "广州农商银行")},
            {"GLB", new Bank("GLB", "桂林银行")},
            {"GDRCU", new Bank("GDRCU", "广东农信银行")},
            {"GDHX", new Bank("GDHX", "广东华兴银行")},
            {"FJNX", new Bank("FJNX", "福建农信银行")},
            {"DYCCB", new Bank("DYCCB", "德阳银行")},
            {"DRCB", new Bank("DRCB", "东莞农商行")},
            {"CZCB", new Bank("CZCB", "稠州银行")},
            {"CZB", new Bank("CZB", "浙商银行")},
            {"CSCB", new Bank("CSCB", "长沙银行")},
            {"CQRCB", new Bank("CQRCB", "重庆农商银行")},
            {"CBHB", new Bank("CBHB", "渤海银行")},
            {"BOIMCB", new Bank("BOIMCB", "内蒙古银行")},
            {"BOD", new Bank("BOD", "东莞银行")},
            {"BOB", new Bank("BOB", "北京银行")},
            {"BNC", new Bank("BNC", "江西银行")},
            {"BJRCB", new Bank("BJRCB", "北京农商行")},
            {"AE", new Bank("AE", "AE")},
            {"GYCB", new Bank("GYCB", "贵阳银行")},
            {"JSHB", new Bank("JSHB", "晋商银行")},
            {"JRCB", new Bank("JRCB", "江阴农商行")},
            {"JNRCB", new Bank("JNRCB", "江南农商")},
            {"JLNX", new Bank("JLNX", "吉林农信")},
            {"JLB", new Bank("JLB", "吉林银行")},
            {"JJCCB", new Bank("JJCCB", "九江银行")},
            {"HXB", new Bank("HXB", "华夏银行")},
            {"HUNNX", new Bank("HUNNX", "湖南农信")},
            {"HSB", new Bank("HSB", "徽商银行")},
            {"HSBC", new Bank("HSBC", "恒生银行")},
            {"HRXJB", new Bank("HRXJB", "华融湘江银行")},
            {"HNNX", new Bank("HNNX", "河南农信")},
            {"HKBEA", new Bank("HKBEA", "东亚银行")},
            {"HEBNX", new Bank("HEBNX", "河北农信")},
            {"HBNX", new Bank("HBNX", "湖北农信")},
            {"GSNX", new Bank("GSNX", "甘肃农信")},
            {"JCB", new Bank("JCB", "JCB")},
            {"MASTERCARD", new Bank("MASTERCARD", "MASTERCARD")},
            {"VISA", new Bank("VISA", "VISA")},
        };

        #endregion

        public static Bank Find(string id)
        {
            Bank card;
            _all.TryGetValue(id, out card);
            return card;
        }

        public static IEnumerable<Bank> GetAll()
        {
            return _all.Values;
        }

        public override string ToString()
        {
            return _id;
        }
    }

    /// <summary>
    /// 银行卡
    /// </summary>
    public class BankCard
    {
        private readonly Bank _bank;
        private readonly BankCardType _type;


        public BankCard(Bank bank, BankCardType type)
        {
            _bank = bank;
            _type = type;
        }

        public Bank Bank
        {
            get { return _bank; }
        }

        /// <summary>
        /// 
        /// </summary>
        public BankCardType Type
        {
            get { return _type; }
        }


        /// <summary>
        /// 解析以下格式的字符串: ICBC_DEBIT
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static BankCard Parse(string code)
        {
            if (code == null)
                return null;

            var index = code.IndexOf('_');
            if (index < 0)
                return null;

            var bankId = code.Substring(0, index);
            var type = (BankCardType)Enum.Parse(typeof(BankCardType), code.Substring(index + 1));

            return new BankCard(Bank.Find(bankId), type);
        }
    }
}
