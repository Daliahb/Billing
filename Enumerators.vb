Public Class Enumerators

    Public Enum EditAdd
        Edit
        Add
    End Enum

    Public Enum CodeType
        TDM = 1
        CLI = 2
        Non_CLI = 3
    End Enum

    Public Enum NON_CLI_Type
        Wholesale = 1
        Retail = 2
    End Enum

    Public Enum TransactionType
        Invoice = 1
        ClientPayment = 2
        Voucher = 3
        Purchase = 4
        MaplePayment = 5
    End Enum

    Public Enum Roles
        Import_Invoices_files = 1
        view_Inserted_Billing = 2
        Generate_weekly_Report = 3
        Generate_Invoices = 4
        Post_Invoices_Send_Emails = 5
        View_Invoices = 6
        Manage_Clients = 7
        Manage_BankAccounts = 8
        Manage_Softwares = 9
        Manage_AccountManager = 10
        Manage_MapleAccounts = 11
        Manage_EmailBody = 12
        Add_Payment = 13
        Add_Voucher = 14
        View_Payments = 15
        View_Vouchers = 16
        View_StatementOfAccount = 17
        View_ClientTransactions = 18
        Manage_BeginingBalances = 19
        Import_Rates = 20
        View_Rates_Reports = 21
        Manage_NonCLI_Type = 22
        Manage_Users = 23
        Manage_Companies = 24
        Client_Performance_Report = 25
        Manage_RecievedAmount = 26
        View_Purchases = 27
        Company_Performance_Report = 28
        Cashflow_Report = 29
        Edit_provide_price = 30
        AM_Performance_Report = 31
    End Enum

    Public Enum DebitCredit
        Debit
        Credit
    End Enum

    Public Enum HistoryType
        Invoice = 1
        ClientPayment = 2
        Voucher = 3
        Log = 4
        Users = 5
        Clients = 6
        Bank = 7
        Company = 8
        EmailBody = 9
        Rates = 10
        Manage = 11
        Purchase = 12
        MaplePayment = 13
        Inquiry = 14
    End Enum

    Public Enum HistoryAction
        Edit = 1
        Add = 2
        Delete = 3
        Log = 4
    End Enum

    Public Enum Agreement
        Unilateral = 1
        Bilateral = 2
    End Enum

    Public Enum VoucherTypes
        Voucher = 1
        BankFees = 2
        Dispute = 3
    End Enum

    Public Enum ClientStatus
        Active = 1
        Disabled = 2
        Maple_Accounts = 3
    End Enum

    Public Enum Priority
        Low = 1
        Medium = 2
        High = 3
    End Enum

    Public Enum OPTP
        OP = 1
        TP = 2
    End Enum
End Class
