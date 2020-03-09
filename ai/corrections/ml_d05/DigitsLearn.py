from NeuralNetwork import *
from Dataset import *
import random
import numpy as np
import matplotlib.pyplot as plt

# Return the number predicted by the network
def getNumber(outs):
    num = 0
    p = outs[0]
    for i in range(1, 10):
        if outs[i] > p:
            p = outs[i]
            num = i
    return num

trainSet = Dataset("Datasets/trainDigits.ds")
testSet = Dataset("Datasets/testDigits.ds")
n = NeuralNetwork([len(trainSet.exemples[0].inputs), len(trainSet.exemples[0].outputs)])

# Matplitlib
fig = plt.gcf()
fig.show()
fig.canvas.draw()
x = []
y = []

threshold = 0.5
loss = threshold
i = 0.
while loss >= threshold:
    ex = random.randint(0, len(trainSet.exemples) - 1)
    n.activate(trainSet.exemples[ex].inputs)
    n.calculateGradients(trainSet.exemples[ex].outputs)
    n.applyGradients(0.5)
    if i % 25 == 0:
        print("Iteration", i)
        loss = n.calcLoss(trainSet)
        x.append(i)
        y.append(loss)
        plt.clf() # Clear
        plt.plot(x, y) # Plot values
        fig.canvas.draw() # Draw curve
        print("Current loss:", loss)
    i += 1

print("Learned :")
sum = 0
for ex in testSet.exemples:
    n.activate(ex.inputs)
    if (getNumber(ex.outputs) == getNumber(n.getOutputs())):
        sum += 1
    print(getNumber(ex.outputs), ":", getNumber(n.getOutputs()), "ERROR" if (getNumber(ex.outputs) != getNumber(n.getOutputs())) else "")

print("Success percentage: ", float(sum) * 100 / len(testSet.exemples))
plt.show() # To keep the window open
