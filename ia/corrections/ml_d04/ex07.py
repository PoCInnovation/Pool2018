
import matplotlib.pyplot as plt


if __name__ == "__main__":

    data_x = [-2, -1, 0, 1, 2.5, 3.5, 4, 5, 6, 7]
    data_y = [202.5, 122.5, 62.5, 22.5, 0, 10.0, 22.5, 62.5, 122.5, 202.5]
    data_der = [-45, -35, -25, -15, 0, 10, 15, 25, 35, 45]

    data_pos_x = []
    data_pos_y = []
    data_neg_x = []
    data_neg_y = []
    data_zero_x = []
    data_zero_y = []
    
    for i in range(0, len(data_x)):
        if data_der[i] > 0:
            data_pos_x.append(data_x[i])
            data_pos_y.append(data_y[i])
        elif data_der[i] < 0:
            data_neg_x.append(data_x[i])
            data_neg_y.append(data_y[i])
        else:
            data_zero_x.append(data_x[i])
            data_zero_y.append(data_y[i])

    plt.scatter(data_pos_x, data_pos_y, c='b')
    plt.scatter(data_neg_x, data_neg_y, c='r')
    plt.scatter(data_zero_x, data_zero_y, c='g')
    plt.plot(data_x, data_y, c='black', zorder=-1)
    plt.xlabel("w")
    plt.ylabel("cost function")
    plt.show()


# Interprétation:
# La fonction de coût est une courbe avec un creux (appelée convexe en mathématiques), le creux représente là où le coût est le plus faible.
# Si la dérivée est > 0 (points bleus), nous voyons graphiquement que nous sommes à droite de la bonne valeur de w, nous devons donc nous déplacer vers la gauche (réduire w)
# Si la dérivée est < 0 (points rouges), nou voyons graphiquement que nous sommes à gauche de la bonne valeur de w, nous devons donc nous déplacer vers la droite (augmenter w)
# La dérivée nous permet donc de savoir comment ajuster w afin de nous déplacer vers le creux de la courbe, c'est à dire vers le w qui nous donnera le coût le plus faible.
