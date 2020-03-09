from Dataset import *
from ex02 import *
from ex04 import *
from ex05 import *
from matplotlib import pyplot
import sys

def k_nearest_neighbors(example, dataset, k):
    return (getMostPresentCategory(getNearestNeighbors(example, dataset, k)))


if __name__ == "__main__":

    train_dataset = Dataset("trainWine.ds")
    test_dataset = Dataset("testWine.ds")
    x = []
    y = []
    for k in range(1, 148):
        correct_prediction = 0
        for i in range(0, len(test_dataset.exemples)):
            prediction = k_nearest_neighbors(test_dataset.exemples[i], train_dataset, k)
            if (prediction == test_dataset.exemples[i].outputs[0]):
                correct_prediction += 1
        x.append(k)
        y.append(correct_prediction)

    pyplot.plot(x, y)
    pyplot.xlabel('K')
    pyplot.ylabel('Correct predictions')
    pyplot.show()
