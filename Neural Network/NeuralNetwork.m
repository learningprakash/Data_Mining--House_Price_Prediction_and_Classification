% Solve an Input-Output Fitting problem with a Neural Network
% Script generated by Neural Fitting app
% Created 08-Apr-2015 11:37:37
%
% This script assumes these variables are defined:
%
%   data - input data.
%   targetdata - target data.
data = load('data.csv');
targetdata = load('targetdata.csv');
x = data';
t = targetdata';

% Choose a Training Function
% For a list of all training functions type: help nntrain
% 'trainlm' is usually fastest.
% 'trainbr' takes longer but may be better for challenging problems.
% 'trainscg' uses less memory. Suitable in low memory situations.
trainFcn = 'trainlm';  % Levenberg-Marquardt backpropagation.

% Create a Fitting Network
hiddenLayerSize = 100;
net = fitnet(hiddenLayerSize,trainFcn);

% Setup Division of Data for Training, Validation, Testing
net.divideParam.trainRatio = 70/100;
net.divideParam.valRatio = 15/100;
net.divideParam.testRatio = 15/100;

% Train the Network
[net,tr] = train(net,x,t);

% Test the Network
y = net(x);
e = gsubtract(t,y);
 
mse_calc = (sum((y-t).^2)/length(y)).^0.5;
p =max(t) - min(t);

nrmse = mse_calc/p;
performance = perform(net,t,y);

y;
dlmwrite('nrmse.txt',nrmse);
dlmwrite('output1.txt',y,'\n');
type output1.txt

% Plots
% Uncomment these lines to enable various plots.
% figure, plotperform(tr)
% figure, plottrainstate(tr)
% figure, ploterrhist(e)
% figure, plotregression(t,y)
% figure, plotfit(net,x,t)
