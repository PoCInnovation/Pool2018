from NeuralNetwork import *
from Dataset import *
import numpy as np
import matplotlib.pyplot as plt
import random

trainSet = Dataset("Datasets/trainTicTacToe.ds")
testSet = Dataset("Datasets/trainTicTacToe.ds")
n = NeuralNetwork([len(trainSet.exemples[0].inputs),\
                   20,\
                   len(trainSet.exemples[0].outputs)])

# Matplitlib
fig = plt.gcf()
fig.show()
fig.canvas.draw()
x = []
y = []

threshold = 0.01
loss = threshold
i = 0.
while loss >= threshold:
    ex = random.randint(0, len(trainSet.exemples) - 1)
    n.activate(trainSet.exemples[ex].inputs)
    n.calculateGradients(trainSet.exemples[ex].outputs)
    n.applyGradients(0.4)
    if i % 1000 == 0:
        print("Iteration", i)
        loss = n.calcLoss(testSet)
        x.append(i)
        y.append(loss)
        plt.clf() # Clear
        plt.plot(x, y) # Plot values
        fig.canvas.draw() # Draw curve
        print("Current loss:", loss)
    i += 1

print("Learned :")
for ex in testSet.exemples:
    n.activate(ex.inputs)
    res = 0
    if n.getOutputs()[0] >= 0.5:
        res = 1
    print(ex.outputs[0], ":", res)

plt.show()
