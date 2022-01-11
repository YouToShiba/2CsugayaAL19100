from scipy import stats
import NewCsv

with open("min.txt") as fMin:
    min = fMin.readlines()[0]

# start.txtの内容をリストに格納
start = []
with open("start.txt") as f:
    for i in f:
        start.append(i.rstrip('\n'))

data = []
data = NewCsv.returnCsvData()

# startとminを用いてdataから情報を抽出，pNNxの計算を行う
count = 0
# 安静&i番目タイトルでのt検定の結果(p値)を格納
result = []

for i in start:
    if count == 0:
        string_rest = [r[4] for r in data[int(i):int(i)+int(min)]]
        float_rest = list(map(float, string_rest))
    else:
        #result.append(stats.ttest_rel(rest, data[int(i):int(i)+int(min)], alternative='two-sided'))
        # dataから抽出，float型へ変換
        string_temp = [r[4] for r in data[int(i):int(i)+int(min)]]
        float_temp = list(map(float, string_temp))

        # 対応ありt検定を行う(返り値はタプル型)
        temptupple = stats.ttest_rel(float_rest, float_temp, alternative='two-sided')
        #resultへ格納
        result.append(temptupple[1])
    count+=1

with open("resultTest.txt", 'w') as f:
    f.write(str(result))

# 有意差あり．i回目に入力したタイトル
count = 1
# print(result)
with open("result.txt", 'w') as f:
    for i in result:
        if i < 0.05:
            f.write(str(count))
            f.write('\n')
        count+=1



