from NeuralNetwork import *
from Dataset import *
import numpy as np
import matplotlib.pyplot as plt

trainSet = Dataset("Datasets/xor.ds")
testSet = Dataset("Datasets/xor.ds")
n = NeuralNetwork([len(trainSet.exemples[0].inputs), 2, 2, 1])

# Matplitlib
fig = plt.gcf()
fig.show()
fig.canvas.draw()
x = []
y = []

i = 0
threshold = 0.01
loss = threshold
while loss >= threshold:
    for ex in trainSet.exemples:
        n.activate(ex.inputs)
        n.calculateGradients(ex.outputs)
        n.applyGradients(0.7)
    if i % 50 == 0:
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
    if (n.getOutputs()[0] >= 0.5):
        res = 1
    print(ex.inputs, ex.outputs, ":", res)

plt.show() # To keep the window open
