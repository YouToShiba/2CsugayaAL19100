# 入力データからt検定に用いる要素数を計算
# 結果はmin.txtに格納

from pathlib import Path
from datetime import datetime
import NewCsv
import sys
import ChangeTime

start = str(sys.argv[1])
finish = str(sys.argv[2])
start = ChangeTime.Change(start)
finish = ChangeTime.Change(finish)
#start = "21:21:46"
#finish = "21:22:22"

data = NewCsv.returnCsvData()

# startからfinishまでの要素数を取得(要素数を一緒にしたいので最小値を求めるため)
count = 1
startRowNum = -1
finishRowNum = -1

while startRowNum == -1 or finishRowNum == -1:
    for i in data:
        if start == i[0] and startRowNum == -1:
            startRowNum = count
        if finish == i[0]:
            finishRowNum = count
            break
        count+=1
    count = 0
    if startRowNum == -1:
        start = ChangeTime.Reset(start)
    if finishRowNum == -1:
        finish = ChangeTime.Reset(finish)

# startの時刻の行数を記録
with open("start.txt", 'a') as f:
    f.write(str(startRowNum))
    f.write('\n')


# min.txtの数と現在取得中の要素数を比較
minChange = False
with open("min.txt") as fMin:
    min = fMin.readlines()[0]
    if int(min) > finishRowNum-startRowNum+1:
        minChange = True

# min.txtの変更が必要なら
if minChange == True:
    with open("min.txt", mode='w') as fMinWrite:
        fMinWrite.write(str(finishRowNum-startRowNum+1))


with open('myfile.txt', mode='a') as f:
    f.write('\n')
    f.write("start:"+str(start))
    f.write('\n')
    f.write("startRowNum:"+str(startRowNum))
    f.write('\n')
    f.write("finish:"+str(finish))
    f.write('\n')
    f.write("finishRowNum:"+str(finishRowNum))
    f.write('\n')
    f.write("num:"+str(finishRowNum-startRowNum+1))
    f.write('\n')
    f.write('\n')

'''
excel：21:12:03表記でも内部上は21:12:03となっている？
python ElementCount.py 21:58:58 21:59:3だと上手くいった

'''
