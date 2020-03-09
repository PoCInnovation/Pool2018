from Neuron import *
from Dataset import *
from random import randint
import numpy as np
import matplotlib.pyplot as plt

trainSet = Dataset("Datasets/trainBinary.ds")
testSet = Dataset("Datasets/testBinary.ds")
n = Neuron(len(trainSet.exemples[0].inputs))

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
    i += 1
    ex = random.randint(0, len(trainSet.exemples) - 1)
    n.activate(trainSet.exemples[ex].inputs)
    n.calculateOutputGradient(trainSet.exemples[ex].outputs[0])
    n.applyGradient(0.5, trainSet.exemples[ex].inputs)
    if i % 10 == 0:
        print("Iteration", i)
        loss = n.calcLoss(trainSet)
        x.append(i)
        y.append(loss)
        plt.clf() # Clear
        plt.plot(x, y) # Plot values
        fig.canvas.draw() # Draw curve
        print("Current loss:", loss)

print("Learned :")
for ex in testSet.exemples:
    n.activate(ex.inputs)
    res = 0
    if (n.out >= 0.5):
        res = 1
    print(ex.outputs[0], ":", res)

plt.show() # To keep the window open
