using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;
/// <summary>
/// Статус клиента банка. Определяет условие ежемесячного обслуживания счета
/// </summary>
public enum ClientStatus
{
    Regular, Premium, VIP
}
