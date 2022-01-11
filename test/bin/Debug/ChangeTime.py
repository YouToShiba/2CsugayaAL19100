import datetime

def Change(time):
    firstFlag = True
    flag = False
    result = ""
    TimeList = list(time)
    for i in TimeList:
        if firstFlag == True and i == "0":    # 0時の場合
            firstFlag = False
        elif i == ":":
            flag = True
            result+=":"
        elif i == "0" and flag == True:    # :0の形だった場合
            flag = False
        elif flag == True:  # :0の形ではなかった場合
            flag = False
            result+=i
        else:
            result+=i
    return result

def Reset(time):
    TimeList = time.split(':')
    dt1 = datetime.datetime(2022, 2, 2, TimeList[0], TimeList[1], TimeList[2])
    dt2 = dt1 + datetime.timedelta(minutes=1)
    dtStr = dt2.hour + ":" + dt2.minute + ":" + dt2.second
    return Change(dtStr)

