// JScript 文件
function installSearchEngineEn()
{
    // Firefox 2 and IE 7, OpenSearch
    if (window.external && ('AddSearchProvider' in window.external))
    {
        window.external.AddSearchProvider('http://amonsoft.cn/exts/open/open_search.xml');
    }
    // Firefox <= 1.5, Sherlock
    else if (window.sidebar && ('addSearchEngine' in window.sidebar))
    {
        window.sidebar.addSearchEngine('http://amonsoft.cn/exts/srch/exts_en_US.src', 'http://amonsoft.cn/logo/logo10.png', 'Extparse', '');
    }
    else
    {
        alert('No search engine support!');
    }
    return false;
}
function installSearchEngineCn()
{
    // Firefox 2 and IE 7, OpenSearch
    if (window.external && ('AddSearchProvider' in window.external))
    {
        window.external.AddSearchProvider('http://amonsoft.cn/exts/open/open_search.xml');
    }
    // Firefox <= 1.5, Sherlock
    else if (window.sidebar && ('addSearchEngine' in window.sidebar))
    {
        window.sidebar.addSearchEngine('http://amonsoft.cn/exts/open/open_search.src', 'http://amonsoft.cn/logo/logo10.png', 'Extparse', '');
    }
    else
    {
        alert('您的浏览器可能不支持搜索引擎！');
    }
    return false;
}