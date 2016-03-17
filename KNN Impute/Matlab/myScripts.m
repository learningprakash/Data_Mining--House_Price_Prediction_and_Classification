inputs = 'C:\Users\Prakash\Desktop\Data Mining\DataFiles\training_data.txt';
targets = 'C:\Users\Prakash\Desktop\Data Mining\DataFiles\Test_Data.txt';
n = 2;

net = configure(net,inputs,targets);
h = @(x) mse_test(x,net,inputs,targets);
ga_opts = gaoptimset('TolFun',1e-8,'display','iter');
[x_ga_opt_err_ga] = ga(h,3*n+1,ga_opts);