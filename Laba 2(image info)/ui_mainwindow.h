/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.14.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTableWidget>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralwidget;
    QPushButton *selectFolderButton;
    QPushButton *selectSingleFileButton;
    QPushButton *selectMultipleFilesButton;
    QPushButton *clearButton;
    QTableWidget *dataHolder;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QString::fromUtf8("MainWindow"));
        MainWindow->resize(800, 600);
        centralwidget = new QWidget(MainWindow);
        centralwidget->setObjectName(QString::fromUtf8("centralwidget"));
        selectFolderButton = new QPushButton(centralwidget);
        selectFolderButton->setObjectName(QString::fromUtf8("selectFolderButton"));
        selectFolderButton->setGeometry(QRect(70, 40, 106, 30));
        selectSingleFileButton = new QPushButton(centralwidget);
        selectSingleFileButton->setObjectName(QString::fromUtf8("selectSingleFileButton"));
        selectSingleFileButton->setGeometry(QRect(240, 40, 106, 30));
        selectMultipleFilesButton = new QPushButton(centralwidget);
        selectMultipleFilesButton->setObjectName(QString::fromUtf8("selectMultipleFilesButton"));
        selectMultipleFilesButton->setGeometry(QRect(390, 40, 106, 30));
        clearButton = new QPushButton(centralwidget);
        clearButton->setObjectName(QString::fromUtf8("clearButton"));
        clearButton->setGeometry(QRect(550, 40, 106, 30));
        dataHolder = new QTableWidget(centralwidget);
        dataHolder->setObjectName(QString::fromUtf8("dataHolder"));
        dataHolder->setGeometry(QRect(230, 180, 256, 192));
        dataHolder->setEditTriggers(QAbstractItemView::NoEditTriggers);
        dataHolder->setSelectionMode(QAbstractItemView::MultiSelection);
        dataHolder->setSelectionBehavior(QAbstractItemView::SelectRows);
        dataHolder->setSortingEnabled(true);
        MainWindow->setCentralWidget(centralwidget);
        menubar = new QMenuBar(MainWindow);
        menubar->setObjectName(QString::fromUtf8("menubar"));
        menubar->setGeometry(QRect(0, 0, 800, 25));
        MainWindow->setMenuBar(menubar);
        statusbar = new QStatusBar(MainWindow);
        statusbar->setObjectName(QString::fromUtf8("statusbar"));
        MainWindow->setStatusBar(statusbar);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QCoreApplication::translate("MainWindow", "MainWindow", nullptr));
        selectFolderButton->setText(QCoreApplication::translate("MainWindow", "\320\222\321\213\320\261\321\200\320\260\321\202\321\214 \320\277\320\260\320\277\320\272\321\203", nullptr));
        selectSingleFileButton->setText(QCoreApplication::translate("MainWindow", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214 \321\204\320\260\320\271\320\273", nullptr));
        selectMultipleFilesButton->setText(QCoreApplication::translate("MainWindow", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214 \321\204\320\260\320\271\320\273\321\213", nullptr));
        clearButton->setText(QCoreApplication::translate("MainWindow", "\320\236\321\207\320\270\321\201\321\202\320\270\321\202\321\214", nullptr));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
