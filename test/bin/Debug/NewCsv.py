from pathlib import Path
import os
import csv

def returnCsvData():
    paths = list(Path('C:\\Users\\izayo\\shibaura\\2C\\sugaya\\5\\PulseMonitor\\PulseSensorAmpd_Processing_1dot1\\csv').glob(r'*.csv'))
    paths.sort(key=os.path.getmtime, reverse=True)

    # ソート結果の表示
    for file in paths:
        fileName = f'{file.name}';
        break

    fileName = 'C:\\Users\\izayo\\shibaura\\2C\\sugaya\\5\\PulseMonitor\\PulseSensorAmpd_Processing_1dot1\\csv\\' + fileName

    data = []

    with open(fileName, encoding='utf8', newline='') as f:
        csvreader = csv.reader(f)
        for row in csvreader:
            # print(row)
            data.append(row)
    return data

# print(returnCsvData())
