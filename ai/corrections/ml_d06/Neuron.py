from __future__ import division
import random
import numpy as np
from Dataset import *
from math import log, tanh

def logistic(x):
    return 1. / (1. + np.exp(-x))

class Neuron:
    def __init__(self, nbEntry):
        self.weights = [random.uniform(-1, 1) for _ in range(nbEntry + 1)]
        self.out = 0.
        self.gradient = 0.

    def activate(self, entries):
        sum = self.weights[0]
        for i in range(1, len(self.weights)):
            sum += self.weights[i] * entries[i - 1]
        self.out = sigmoid(sum)

    def activateWithLayer(self, prevLayer):
        sum = self.weights[0]
        for i in range(1, len(self.weights)):
            sum += self.weights[i] * prevLayer[i - 1].out
        self.out = logistic(sum)

    # Calculate the loss average on a dataset
    def calcLoss(self, dataset):
        loss = 0.
        for ex in dataset.exemples:
            self.activate(ex.inputs)
            loss += ex.outputs[0] * log(self.out) +\
                    (1. - ex.outputs[0]) * log(1. - self.out)
        return -loss / len(dataset.exemples)

    def calculateOutputGradient(self, desiredOutput):
        self.gradient = (desiredOutput - self.out)

    def calculateHiddenGradient(self, nextLayer, idx):
        sum = 0.
        for k in nextLayer:
            sum += k.gradient * k.weights[idx + 1]
        self.gradient = (1 - self.out) * self.out * sum

    # For single neuron uses
    def applyGradient(self, learningRate, entries):
        self.weights[0] += learningRate * self.gradient
        for i in range(1, len(self.weights)):
            self.weights[i] += learningRate * self.gradient *\
                               entries[i - 1]

    # For Neural Network uses
    def applyGradientWithLayer(self, learningRate, entries):
        self.weights[0] += learningRate * self.gradient
        for i in range(1, len(self.weights)):
            self.weights[i] += (learningRate * self.gradient *\
                               entries[i - 1].out)
